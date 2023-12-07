using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp21.Services
{
   public class JsonH
    {
        public static async Task<string> getData(string url,string imgName)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"keyName\": \""+ imgName + "\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var output = JObject.Parse(response.Content);

            return output.Value<string>("result");
        }
       
    }
}
