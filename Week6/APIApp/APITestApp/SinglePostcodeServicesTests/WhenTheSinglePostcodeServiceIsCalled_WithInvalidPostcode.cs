using APIClientApp.PostcodesIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.SinglePostcodeServicesTests
{
    [Category("Sad Path")]
    public class WhenTheSinglePostcodeServiceIsCalled_WithInvalidPostcode
    {
        SinglePostcodeService _singlePostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequestAsync("csfdv");
        }

        [Test]
        public void StatusIs404_InJsonResponse()
        {
            Assert.That(_singlePostcodeService.JsonResponse["status"].ToString(), Is.EqualTo("404"));
        }

        [Test]
        public void StatusIs404()
        {
            Assert.That(_singlePostcodeService.GetStatusCode, Is.EqualTo(404));
        }

        [Test]
        public void StatusInResponseHeader_SameAsResponseBody()
        {
            var bodyResponseStatusCode = _singlePostcodeService.JsonResponse["status"].ToString();
            var bodyResponseStatusCodeInt = int.Parse(bodyResponseStatusCode.ToString());
            Assert.That(_singlePostcodeService.GetStatusCode, Is.EqualTo(bodyResponseStatusCodeInt));
        }

        [Test]
        public void ObjectStatusIs404()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.Status, Is.EqualTo(404));
        }

    }
}
