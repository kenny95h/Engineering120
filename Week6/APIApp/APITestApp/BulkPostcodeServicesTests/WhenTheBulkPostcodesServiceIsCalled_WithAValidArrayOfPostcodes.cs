using APIClientApp.PostcodesIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.BulkPostcodeServicesTests
{
    [Category("Happy Path")]
    public class WhenTheBulkPostcodesServiceIsCalled_WithAValidArrayOfPostcodes
    {
        BulkPostcodeService _bulkPostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _bulkPostcodeService = new BulkPostcodeService();
            await _bulkPostcodeService.MakeRequestAsync("PR3 0SG, M45 6GN, EX16 5BL");
        }

        [Test]
        public void StatusIs200_InJsonResponse()
        {
            Assert.That(_bulkPostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_bulkPostcodeService.GetStatusCode, Is.EqualTo(200));
        }

        [Test]
        public void StatusInResponseHeader_SameAsResponseBody()
        {
            var bodyResponseStatusCode = _bulkPostcodeService.ResponseContent["status"].ToString();
            var bodyResponseStatusCodeInt = int.Parse(bodyResponseStatusCode.ToString());
            Assert.That(_bulkPostcodeService.GetStatusCode, Is.EqualTo(bodyResponseStatusCodeInt));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_bulkPostcodeService.ResponseObject.Status, Is.EqualTo(200));
        }

        [Test]
        public void RegionOfSecondObject_IsNorthWest()
        {
            Assert.That(_bulkPostcodeService.ResponseObject.result[1].result.region, Is.EqualTo("North West"));
        }

        public void AdminCountyOfSecondObject_IsNull()
        {
            Assert.That(_bulkPostcodeService.ResponseObject.result[1].result.region, Is.Null);
        }
    }
}
