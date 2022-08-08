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
    public class SinglePostcodeService 
    {
        #region Properties
        //RestSharp object which handles comms with the API
        //public RestClient? Client { get; set; }
        ////Captures the response
        //public RestResponse? Response { get; set; }
        public CallManager CallManager { get; set; }
        //Capture the response body JSON
        public JObject JsonResponse { get; set; }
        //public SinglePostcodeResponse ResponseObject { get; set; }
        public DTO<SinglePostcodeResponse> SinglePostcodeDTO { get; set; }
        public string PostcodeResponse { get; set; }
        #endregion
        public SinglePostcodeService()
        {
            //Client = new RestClient(AppConfigReader.BaseUrl);
            CallManager = new CallManager();
            SinglePostcodeDTO = new DTO<SinglePostcodeResponse>();
        }

        // Method that defines and makes the API request and stores the response
        /// <summary>
        /// defines and makes the API request, and stores the response
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        public async Task MakeRequestAsync(string postcode, string path = "postcodes/")
        {
            //set up request
            //var request = new RestRequest();
            //request.AddHeader("Content-Type", "application/Json");
            //request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            ////Make request
            //Response = await Client.ExecuteAsync(request);

            //////Parse JSON body to ResponseContent
            //JsonResponse = JObject.Parse(Response.Content);

            ////an object model of the response
            //ResponseObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(Response.Content);
            PostcodeResponse = await CallManager.MakePostcodeRequestAsync(postcode, path);
            JsonResponse = JObject.Parse(PostcodeResponse);
            //Use DTO to convert JSON string to an object tree
            SinglePostcodeDTO.DeserialiseResponse(PostcodeResponse);
        }

        public int GetStatusCode()
        {
            //Returns status code
            return (int)CallManager.Response.StatusCode;
        }

        public int CodeCount()
        {
            return JsonResponse["result"]["codes"].Count();
        }

        public string GetAdminCountyCodes()
        {
            return JsonResponse["result"]["codes"]["admin_county"].ToString();
        }
    }
}
