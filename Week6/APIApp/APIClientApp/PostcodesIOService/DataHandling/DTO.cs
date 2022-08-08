using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService.DataHandling
{
    public class DTO<ResponseType> where ResponseType : IResponse, new()
    {
        //The class is the model of the data returned by the API call
        public ResponseType Response { get; set; }
        internal void DeserialiseResponse(string postcodeResponse)
        {
            Response = JsonConvert.DeserializeObject<ResponseType>(postcodeResponse);
        }
    }
}
