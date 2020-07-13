using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    static class Utilities
    {
        public static string getToken()
        {
            HttpWebRequest request = null;
            request = (HttpWebRequest)WebRequest.Create("https://localhost:44327/api/Admin/authenticate");
            request.Method = "POST";
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            var RequestData = new
            {
                Username = "9111",
                Password = "123@456"
            };
            string stringPayload = JsonConvert.SerializeObject(RequestData);
            Byte[] byteArray = encoding.GetBytes(stringPayload);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the response stream  
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string getDataToString = reader.ReadToEnd();

            //JObject RespondData = jss.Deserialize<JObject>(getDataToString);
            JObject RespondData = JsonConvert.DeserializeObject<JObject>(getDataToString);

            string token = RespondData["token"].ToString();

            return token;
        }
    }
}
