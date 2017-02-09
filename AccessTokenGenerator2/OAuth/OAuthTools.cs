using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccessTokenGenerator2
{

    public class OAuthTools
    {
        /// <summary>
        /// OAuth2 Hilfsmethoden
        /// </summary>
        public OAuthTools()
        {

        }

        public string parseParameter(string url, string parameter)
        {
            string paramValue = "";

            int pos = url.IndexOf(parameter);
            paramValue = url.Substring(pos + parameter.Length + 1);

            //ggf noch weitere &-Parameter abtrennen?
            if (paramValue.Contains("&"))
            {
                paramValue = paramValue.Substring(0, paramValue.IndexOf("&"));
            }

            return paramValue;
        }

        public OAuthResponse getTokenWithAuthCode(string parameters, string url)
        {

            OAuthResponse oAuthResponse = new OAuthResponse();

            //WebClient anlegen
            WebClient myWebClient = new WebClient();

            //Content Typ URLENCODED notwendig
            myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            //Except100 ausschalten, sonst gibt es u. U. Fehlermeldungen
            ServicePointManager.Expect100Continue = false;

            byte[] antwort = null;
            byte[] param = Encoding.UTF8.GetBytes(parameters);

            string response = "";

            try
            {
                antwort = myWebClient.UploadData(url, "POST", param);
                response = System.Text.Encoding.ASCII.GetString(antwort);

                //bei Plain-Text Antworten sind die ersten 13 Zeichen "access_token=" und können entfernt werden
                //in diesem Fall wird auch kein expires zurückgegeben
                if (response.StartsWith("access_token="))
                {
                    oAuthResponse.success = true;
                    oAuthResponse.accessToken = response.Remove(0, 13);
                }
                else if (response.StartsWith("{"))
                {
                    //dann ist die Antwort JSON: deserialisieren
                    MemoryStream ms = new MemoryStream(antwort);
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(JsonAccessToken));
                    JsonAccessToken token = ser.ReadObject(ms) as JsonAccessToken;
                    oAuthResponse.success = true;
                    oAuthResponse.accessToken = token.access_token;
                    oAuthResponse.expires = token.expires_in;
                }

            }
            catch (Exception ex)
            {
                oAuthResponse.success = false;
                oAuthResponse.errorMessage = ex.Message;
            }

            return oAuthResponse;
        }

        public string getJsonData(string url)
        {
            //WebClient anlegen
            WebClient myWebClient = new WebClient();

            byte[] antwort = null;
            string response = "";

            try
            {
                antwort = myWebClient.DownloadData(url);
                response = System.Text.Encoding.ASCII.GetString(antwort);
            }
            catch (Exception ex)
            {
                response = "Error: " + ex.Message;
            }

            //Ausgabe etwas übersichtlicher gestalten:
            response = response.Replace(",", ",\n\r");
            response = response.Replace("{", "\n\r{");

            return response;
        }

        public string[] analyseBrowserResult(string textNavigation, string clientID, string clientSecret, string redirUrl, string endPoint)
        {
            string logMessage = "";

            //ist in der URL bereits ein Access-Token?
            if (textNavigation.Contains("access_token="))
            {
                string accesstoken = parseParameter(textNavigation, "access_token");
                return new string[] { accesstoken, logMessage };
            }
            //Oder Auth-Code?
            else if (textNavigation.Contains("code="))
            {
                string code = parseParameter(textNavigation, "code");

                string parametersForPost = ""
                    + "client_id=" + clientID
                    + "&client_secret=" + clientSecret
                    + "&grant_type=authorization_code"
                    + "&redirect_uri=" + redirUrl
                    + "&code=" + code;

                logMessage += "Get Access Token with Code, Params: " + parametersForPost + "\r\n";

                OAuthResponse oAuthResponse = getTokenWithAuthCode(parametersForPost, endPoint);

                if (oAuthResponse.success)
                {
                    logMessage += "Access Token found: " + oAuthResponse.accessToken;

                    if (oAuthResponse.expires>0)
                    { 
                        int days = oAuthResponse.expires / 60 / 60 / 24;
                        logMessage+="\r\nAccess Token expires in: " + oAuthResponse.expires.ToString() + " seconds (" + days + " days)";
                    }
                    return new string[] { oAuthResponse.accessToken, logMessage };
                }
                else
                {
                    return new string[] { "Response (Error): " + oAuthResponse.errorMessage, logMessage };
                }
            }
            else
            {
                return new string[] { "Unknown Error", logMessage };
            }
        }
    }
}
