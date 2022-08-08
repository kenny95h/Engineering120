using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIClientApp.PostcodesIOService.DataHandling;
using APIClientApp.PostcodesIOService.HTTPManager;

namespace APIClientApp.PostcodesIOService
{
    public class OutcodeService
    {
        #region Properties
        //RestSharp object which handles comms with the API
        //public RestClient? Client { get; set; }
        ////Captures the response
        //public RestResponse? Response { get; set; }
        ////Capture the response body JSON
        //public JObject ResponseContent { get; set; }

        //public OutcodeResponse ResponseObject { get; set; }
        public CallManager CallManager { get; set; }
        //Capture the response body JSON
        public JObject JsonResponse { get; set; }
        //public SinglePostcodeResponse ResponseObject { get; set; }
        public DTO<OutcodeResponse> OutcodeDTO { get; set; }
        public string OutcodeResponse { get; set; }
        #endregion
        public OutcodeService()
        {
            //Client = new RestClient(AppConfigReader.BaseUrl);
            CallManager = new CallManager();
            OutcodeDTO = new DTO<OutcodeResponse>();
        }
        public async Task MakeRequestAsync(string outcode, string path = "outcodes/")
        {
            //set up request
            //var request = new RestRequest();
            //request.AddHeader("Content-Type", "application/Json");
            //request.Resource = $"outcodes/{outcode.ToLower()}";

            ////Make request
            //Response = await Client.ExecuteAsync(request);

            ////Parse JSON body to ResponseContent
            //ResponseContent = JObject.Parse(Response.Content);

            ////an object model of the response
            //ResponseObject = JsonConvert.DeserializeObject<OutcodeResponse>(Response.Content);
            OutcodeResponse = await CallManager.MakePostcodeRequestAsync(outcode, path);
            JsonResponse = JObject.Parse(OutcodeResponse);
            //Use DTO to convert JSON string to an object tree
            OutcodeDTO.DeserialiseResponse(OutcodeResponse);
        }

        public int GetStatusCode()
        {
            //Returns status code
            return (int)CallManager.Response.StatusCode;
        }

    }
}
