using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Data.Model;
using Newtonsoft.Json;

namespace Business
{
    public static class APIQueries
    {
        public static string appKey = "48e0e99760885527f11b63e7fd2963a9";
        public static string appId = "7691d4c8";

        private static string baseURL = "https://od-api.oxforddictionaries.com/api/v1";
        public static string URL;
        public static WebRequest request;

        public static string GetEntries(string lang, string word)
        {
            URL = baseURL + $"/entries/{lang}/{word}";
            MakeRequest();
            return GetResponse();
        }

        public static string GetSynonymsAntonyms(string lang, string word)
        {
            URL = baseURL + $"/entries/{lang}/{word}/synonyms;antonyms;";
            MakeRequest();
            return GetResponse();
        }

        public static string GetLemmasInflections(string lang, string word)
        {
            URL = baseURL + $"/inflections/{lang}/{word}:";
            MakeRequest();
            return GetResponse();
        }

        public static void MakeRequest()
        {
            request = WebRequest.Create(URL);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Headers["Accept"] = "application/json";
            request.Headers["app_id"] = appId;
            request.Headers["app_key"] = appKey;
        }

        public static string GetResponse()
        {
            try
            {
                WebResponse response = request.GetResponse();

                string responseFromServer;

                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        responseFromServer = reader.ReadToEnd();
                    }
                }

                return responseFromServer;
            }
            catch (WebException e)
            {
                throw e;
            }

        }
    }
}
