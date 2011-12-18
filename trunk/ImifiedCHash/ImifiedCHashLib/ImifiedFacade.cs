/// <FileName>ImifiedFacade.cs</FileName>
/// <copyright>
/// Copyright Brijrajsingh.com, available under MIT Licence
/// All this work may be used, practiced, performed, copied, distributed, 
/// revised, modified, translated, abridged, condensed, expanded, collected, 
/// compiled, linked, recast or adapted. 
/// A reference will be very much appreciated.
/// <copyright>
/// <remarks>
/// Date           Author              Changes
///13,Dec 2011     brijraj singh       Created
///Copyright (c) 2011 Brijrajsingh.com, MIT Licence
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;


namespace ImifiedCHashLib
{
    /// <summary>
    /// Class provides facade based implementation for 
    /// </summary>
    public static class ImifiedFacade
    {

             
        /// <summary>
        /// Queries the Bot for all users connected/disconnected to it.        
        /// </summary>
        /// <param name="NetworkName"> NetworkNAme - Optional, use this to filter out the users of a particular bot.</param>
        /// <returns>XML structure of all user details</returns>
        public static string GetAllUsers(string NetworkName=null)
        {
            string _allUsersXml = string.Empty;
            string _botkey = ConfigurationManager.AppSettings["botKey"];
            string _username = ConfigurationManager.AppSettings["username"];
            string _password = ConfigurationManager.AppSettings["password"];           
           
            string _postData = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)(WebRequest.Create("https://www.imified.com/api/bot/"));
                request.Method = "POST";

                if ((NetworkName != null) && (NetworkName != string.Empty))
                {
                    _postData = "botkey=" + _botkey + "&apimethod=getAllUsers&" + "networkname=" + NetworkName ;
                }
                else
                {
                    _postData = "botkey=" + _botkey + "&apimethod=getAllUsers";
                }

                byte[] _bytes;
                System.Text.ASCIIEncoding _a = new ASCIIEncoding();
                _bytes = _a.GetBytes(_username + ":" + _password);

                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(_bytes, 0, _bytes.Length));


                byte[] byteArray = Encoding.UTF8.GetBytes(_postData);

                // Set the ContentType property of the WebRequest.

                request.ContentType = "application/x-www-form-urlencoded";

                // Set the ContentLength property of the WebRequest.

                request.ContentLength = byteArray.Length;

                // Get the request stream.

                Stream dataStream = request.GetRequestStream();

                // Write the data to the request stream.

                dataStream.Write(byteArray, 0, byteArray.Length);

                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();

                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                _allUsersXml = reader.ReadToEnd();

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

            }
            catch (Exception ex)
            {
                throw;
            }

            return _allUsersXml;
        }


        /// <summary>
        /// Find the given username in the network{optional} or all the BOT networks, and return the unique Userid
        /// </summary>
        /// <param name="UserName">ChatID of the User</param>
        /// <param name="NetworkName">NetworkNAme - Optional, use this to filter out the users of a particular bot.</param>
        /// <returns>Unique userid</returns>
        public static string GetUserIdByUserName(string UserName, string NetworkName = null)
        {
            string _allusersXML = GetAllUsers(NetworkName);
            string _userKey = string.Empty;

            string strRegex = @"([A-Za-z0-9\-]+)\</userkey>";
            RegexOptions myRegexOptions = RegexOptions.Multiline | RegexOptions.Singleline;
            Regex myRegex = new Regex(strRegex, myRegexOptions);
            string strTargetString = _allusersXML;

            foreach (Match myMatch in myRegex.Matches(strTargetString))
            {
                if (myMatch.Success)
                {                    
                    _userKey = myMatch.Captures[0].Value.Replace("</userkey>", string.Empty);
                    break;
                }
                else
                {
                    _userKey = string.Empty;                    
                }
            }

            return _userKey;
        }


        /// <summary>
        /// Send the message to given userkey/userid 
        /// </summary>
        /// <param name="UserKey">Unique UserKey or USerId</param>
        /// <param name="MessageText">Message to be sent</param>
        /// <returns>Success/Failure/User Not Found</returns>
        public static string SendMessage(string UserKey, string MessageText)
        {
            string _retVal = string.Empty;
            string _botkey = ConfigurationManager.AppSettings["botKey"];
            string _username = ConfigurationManager.AppSettings["username"];
            string _password = ConfigurationManager.AppSettings["password"];
            
            
            try 
	           {	        
		
                HttpWebRequest request = (HttpWebRequest)(WebRequest.Create("https://www.imified.com/api/bot/"));
                request.Method = "POST";

                string postData = "botkey=" + _botkey + "&apimethod=send&userkey=" + UserKey + "&msg=" + MessageText;

                byte[] _bytes;
                System.Text.ASCIIEncoding _a = new ASCIIEncoding();
                _bytes = _a.GetBytes(_username + ":" + _password);

                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(_bytes, 0, _bytes.Length));


                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentType property of the WebRequest.

                request.ContentType = "application/x-www-form-urlencoded";

                // Set the ContentLength property of the WebRequest.

                request.ContentLength = byteArray.Length;

                // Get the request stream.

                Stream dataStream = request.GetRequestStream();

                // Write the data to the request stream.

                dataStream.Write(byteArray, 0, byteArray.Length);

                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();

                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                _retVal = reader.ReadToEnd();
            
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }

            return _retVal;

        }


    }
}
