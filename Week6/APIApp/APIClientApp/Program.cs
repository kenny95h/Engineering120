using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using APIClientApp.PostcodesIOService.DataHandling;

namespace APIClientApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Encapsulate the information we need to make the api call
            //We can make authenticated HTTP requests
            var restClient = new RestClient("https://api.postcodes.io/");


            //Set up the request. Create a request object
            var restRequest = new RestRequest();
            //Not needed as it is defaulted and inferred
            restRequest.Method = Method.Get;
            restRequest.AddHeader("Content-Type", "application/json");
            // Set up the resources
            var postcode = "EC2Y 5AS";
            restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            //Execute request
            var singlePostcodeResponse = await restClient.ExecuteAsync(restRequest);

            // Interegate body response
            //Console.WriteLine("Response content (string)");
            //Console.WriteLine(singlePostcodeResponse.Content);

            //Interegate status code
            //Console.WriteLine("Response code (enum)");
            //Console.WriteLine(singlePostcodeResponse.StatusCode);
            //Console.WriteLine("Response code (int)");
            //Console.WriteLine((int)singlePostcodeResponse.StatusCode);

            //Console.WriteLine("Headers");
            //foreach (var item in singlePostcodeResponse.Headers)
            //{
            //    Console.WriteLine(item);
            //}

            //Interegate headers
            var responseContentType = singlePostcodeResponse.Headers.Where(x => x.Name == "Date").Select(h => h.Value.ToString()).FirstOrDefault();
            //Console.WriteLine(responseContentType);

            var client = new RestClient();
            var request = new RestRequest("https://api.postcodes.io/postcodes/", Method.Post);
            request.AddHeader("Content-Type", "application/json");

            // request body as string
            // request.AddStringBody("{\r\n\"postcodes\" : [\"OX49 5NU\", \"M32 0JG\", \"NE30 1DP\"]\r\n}\r\n", DataFormat.Json);

            // request body from c# object
            var postCodes = new
            {
                Postcodes = new string[] { "PR3 0SG", "M45 6GN", "EX165BL" }
            };
            // add object to request
            request.AddJsonBody(postCodes);
            RestResponse bulkPostcodeResponse = client.Execute(request);
            //Console.WriteLine(bulkPostcodeResponse.Content);

            // Converts response content to JSON Object - allows us to query the JObject
            //var singlePostcodeJsonResponse = JObject.Parse(singlePostcodeResponse.Content);
            //Console.WriteLine(singlePostcodeResponse);
            //var adminDistrict = singlePostcodeJsonResponse["result"]["admin_district"];
            //Console.WriteLine(adminDistrict);

            // Repeat with bulk postcode response
            var bulkPostcodeJsonResponse = JObject.Parse(bulkPostcodeResponse.Content);
            var bulkAdminDistrict = bulkPostcodeJsonResponse["result"][1]["result"]["codes"]["admin_county"];
            //Console.WriteLine(bulkAdminDistrict);

            var list = bulkPostcodeJsonResponse["result"].ToList();

            var singlePostcodeObjectResponse = JsonConvert.DeserializeObject<SinglePostcodeResponse>(singlePostcodeResponse.Content);
            var bulkPostcodeObjectResponse = JsonConvert.DeserializeObject<BulkPostcodeResponse>(bulkPostcodeResponse.Content);

            //foreach (var p in bulkPostcodeObjectResponse.result)
            //{
            //    Console.WriteLine(p.query);
            //    Console.WriteLine(p.result.admin_county);
            //}

            var selectedAdminCounty = bulkPostcodeObjectResponse.result.Where(x => x.query == "PR3 0SG").FirstOrDefault().result.admin_county;
            //Console.WriteLine(selectedAdminCounty);
            //var selectedAdminCountyAlt = bulkPostcodeObjectResponse.result[0].result.admin_county;
            //Console.WriteLine(selectedAdminCountyAlt);


            // Outcodes version
            var outClient = new RestClient();
            string outcode = "pr3";
            var outRequest = new RestRequest($"https://api.postcodes.io/outcodes/{outcode}", Method.Get);
            outRequest.AddHeader("Content-Type", "application/json");
            RestResponse outcodeResponse = outClient.Execute(outRequest);


            var outcodeJsonResponse = JObject.Parse(outcodeResponse.Content);
            Console.WriteLine(outcodeJsonResponse);

            var outcodeObjectResponse = JsonConvert.DeserializeObject<OutcodeResponse>(outcodeResponse.Content);

            foreach (var o in outcodeObjectResponse.result.admin_ward)
            {
                Console.WriteLine(o);
            }


           
        }
    }
}