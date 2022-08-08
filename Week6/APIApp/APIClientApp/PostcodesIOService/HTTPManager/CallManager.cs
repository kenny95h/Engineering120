using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService.HTTPManager
{
    public class CallManager
    {
        public enum Services
        {

        }
        #region properties

        private readonly RestClient _client;
        public RestResponse Response { get; set; }

        #endregion

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }

        public async Task<string> MakePostcodeRequestAsync(string postcode, string path)
        {
            // set up request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/Json");
            request.Resource = $"{path}{postcode.ToLower().Replace(" ", "")}";

            // executing request
            Response = await _client.ExecuteAsync(request);
            return Response.Content;

        }
    }
}
