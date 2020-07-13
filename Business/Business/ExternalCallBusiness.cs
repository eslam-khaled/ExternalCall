using DTOs.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class ExternalCallBusiness
    {
        
        public ResponseDTO Execute(ApiNotificationDTO apiNotificationDTO)
        {
            string token = Utilities.getToken();
            string URL = "https://localhost:44327/api/Notifications/ExternalSendNotificationSaveToInboxbyAccountNumber";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 1000000;
            httpWebRequest.KeepAlive = true;

            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);

            string stringPayload = JsonConvert.SerializeObject(apiNotificationDTO);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(stringPayload);
                streamWriter.Flush();
                streamWriter.Close();
            }
            ResponseDTO result = new ResponseDTO();
            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
                string getDataToString = reader.ReadToEnd();

                JObject respondData = JsonConvert.DeserializeObject<JObject>(getDataToString);

                 result = respondData.ToObject<ResponseDTO>();

                return result;

            }
            catch (WebException ex)
            {
                result.success = false;
                result.message = "There is a problem in Money Transfer, please try in another time.";
                result.messageAR = "يوجد مشكلة بعملية التحويل، الرجاء المحاولة في وقت آخر.";
                result.SystemError = ex.Message;
                return result;
            }

        }


    }
}
