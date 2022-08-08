using APIClientApp.PostcodesIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.SinglePostcodeServicesTests
{
    [Category("Happy Path")]
    public class WhenTheSinglePostcodeServiceIsCalled_WithValidPostcode
    {
        SinglePostcodeService _singlePostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequestAsync("EC2Y 5AS");
        }

        [Test]
        public void StatusIs200_InJsonResponse()
        {
            Assert.That(_singlePostcodeService.JsonResponse["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_singlePostcodeService.GetStatusCode, Is.EqualTo(200));
        }

        [Test]
        public void StatusInResponseHeader_SameAsResponseBody()
        {
            var bodyResponseStatusCode = _singlePostcodeService.JsonResponse["status"].ToString();
            var bodyResponseStatusCodeInt = int.Parse(bodyResponseStatusCode.ToString());
            Assert.That(_singlePostcodeService.GetStatusCode, Is.EqualTo(bodyResponseStatusCodeInt));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.Status, Is.EqualTo(200));
        }

        [Test]
        public void CorrectPostcodeIsReturned()
        {
            var result = _singlePostcodeService.JsonResponse["result"]["postcode"].ToString();
            Assert.That(result, Is.EqualTo("EC2Y 5AS"));
        }

        [Test]
        public void Country_IsEngland()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.result.country, Is.EqualTo("England"));
        }

        [Test]
        public void CodesAdminCounty_IsE99999999()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.result.codes.admin_county, Is.EqualTo("E99999999"));
        }

        [Test]
        public void AdminCountyIsNull_ReturnNull()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.result.admin_county, Is.Null);
        }

        [Test]
        public void ContentType_IsJson()
        {
            Assert.That(_singlePostcodeService.CallManager.Response.ContentType, Is.EqualTo("application/json"));
        }

        [Test]
        public void CodeCount_IsCorrect()
        {
            Assert.That(_singlePostcodeService.CodeCount(), Is.EqualTo(12));
        }

        [Test]
        public void AdminCountyCode_IsCorrect()
        {
            Assert.That(_singlePostcodeService.GetAdminCountyCodes(), Is.EqualTo("E99999999"));
        }
    }
}
