using APIClientApp.PostcodesIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.OutcodeServicesTests
{
    [Category("Sad Path")]
    public class WhenTheOutcodeServiceIsCalled_WithAnInvalidOutcode
    {
        OutcodeService _outcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _outcodeService = new OutcodeService();
            await _outcodeService.MakeRequestAsync("ruw8ru8");
        }

        [Test]
        public void StatusIs404_InJsonResponse()
        {
            Assert.That(_outcodeService.JsonResponse["status"].ToString(), Is.EqualTo("404"));
        }

        [Test]
        public void StatusIs404()
        {
            Assert.That(_outcodeService.GetStatusCode, Is.EqualTo(404));
        }

        [Test]
        public void StatusInResponseHeader_SameAsResponseBody()
        {
            var bodyResponseStatusCode = _outcodeService.JsonResponse["status"].ToString();
            var bodyResponseStatusCodeInt = int.Parse(bodyResponseStatusCode.ToString());
            Assert.That(_outcodeService.GetStatusCode, Is.EqualTo(bodyResponseStatusCodeInt));
        }

        [Test]
        public void ObjectStatusIs404()
        {
            Assert.That(_outcodeService.OutcodeDTO.Response.status, Is.EqualTo(404));
        }
    }
}
