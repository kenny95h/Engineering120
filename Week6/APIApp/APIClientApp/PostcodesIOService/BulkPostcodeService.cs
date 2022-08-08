using APIClientApp.PostcodesIOService.DataHandling;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService
{
    public class BulkPostcodeService
    {
        #region Properties
        //RestSharp object which handles comms with the API
        public RestClient? Client { get; set; }
        //Captures the response
        public RestResponse? Response { get; set; }
        //Capture the response body JSON
        public JObject ResponseContent { get; set; }

        public BulkPostcodeResponse ResponseObject { get; set; }
        #endregion
        public BulkPostcodeService()
        {
            Client = new RestClient(AppConfigReader.BaseUrl);
        }

        // Method that defines and makes the API request and stores the response
        public async Task MakeRequestAsync(string postcodes, string path = "postcodes/")
        {
            //set up request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/Json");
            request.Method = Method.Post;
            request.Resource = "postcodes/";
            string[] postcodesIn = postcodes.Split(',');
            var anonPostcodes = new
            {
                Postcodes = postcodesIn
            };
            request.AddJsonBody(anonPostcodes);
            //Make request
            Response = await Client.ExecuteAsync(request);

            //Parse JSON body to ResponseContent
            ResponseContent = JObject.Parse(Response.Content);

            //an object model of the response
            ResponseObject = JsonConvert.DeserializeObject<BulkPostcodeResponse>(Response.Content);
        }

        public int GetStatusCode()
        {
            //Returns status code
            return (int)Response.StatusCode;
        }
    }
}
