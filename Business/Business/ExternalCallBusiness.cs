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
        public ResponseDTO Execute()
        {
            string URL = "https://localhost:44327/api/Notifications/SendNotificationSaveToInboxbyAccountNumber";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 1000000;
            httpWebRequest.KeepAlive = true;

            //string TokenParts = coreToken.Substring(0, 2)
            //                    + coreToken.Substring(20, 2)
            //                    + coreToken.Substring(10, 2)
            //                    + coreToken.Substring(15, 2)
            //                    + coreToken.Substring(5, 2);
            //httpWebRequest.Headers.Add("CheckSum", CheckSum.CreateCheckSum(stringPayload, referenceNumber + TokenParts + coreCheckSumPassword));
            //httpWebRequest.Headers.Add("Token", coreToken);
            //httpWebRequest.Headers.Add("ReferenceNo", referenceNumber);

            // Connecting to the server. Sending request and receiving response
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //streamWriter.Write(stringPayload);
                streamWriter.Flush();
                streamWriter.Close();
            }

            ResponseDTO baseResponseDto = new ResponseDTO();
            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
                string getDataToString = reader.ReadToEnd();

                JObject respondData = JsonConvert.DeserializeObject<JObject>(getDataToString);

                ResponseDTO Header = respondData.ToObject<ResponseDTO>();

                return baseResponseDto;

            }
            catch (WebException ex)
            {
                baseResponseDto.success = false;
                baseResponseDto.message = "There is a problem in Money Transfer, please try in another time.";
                baseResponseDto.messageAR = "يوجد مشكلة بعملية التحويل، الرجاء المحاولة في وقت آخر.";
                baseResponseDto.SystemError = ex.Message;
                return baseResponseDto;
            }

        }
    }
}
