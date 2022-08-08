using APIClientApp.PostcodesIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.OutcodeServicesTests
{
    [Category("Happy Path")]
    public class WhenTheOutcodeServiceIsCalled_WithValidOutcode
    {
        OutcodeService _outcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _outcodeService = new OutcodeService();
            await _outcodeService.MakeRequestAsync("PR3");
        }

        [Test]
        public void StatusIs200_InJsonResponse()
        {
            Assert.That(_outcodeService.JsonResponse["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_outcodeService.GetStatusCode, Is.EqualTo(200));
        }

        [Test]
        public void StatusInResponseHeader_SameAsResponseBody()
        {
            var bodyResponseStatusCode = _outcodeService.JsonResponse["status"].ToString();
            var bodyResponseStatusCodeInt = int.Parse(bodyResponseStatusCode.ToString());
            Assert.That(_outcodeService.GetStatusCode, Is.EqualTo(bodyResponseStatusCodeInt));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_outcodeService.OutcodeDTO.Response.status, Is.EqualTo(200));
        }

        [Test]
        public void ContentType_IsJson()
        {
            Assert.That(_outcodeService.CallManager.Response.ContentType, Is.EqualTo("application/json"));
        }

        [Test]
        public void NumberOfElementsInArrayOfAdminDistrict_Is5()
        {
            Assert.That(_outcodeService.OutcodeDTO.Response.result.admin_district.Count, Is.EqualTo(5));
        }
    }
}
