using APIClientApp.PostcodesIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.BulkPostcodeServicesTests
{
    [Category("Sad Path")]
    public class WhenTheBulkPostcodesServiceIsCalled_WithAnInvalidArrayOfPostcodes
    {
        BulkPostcodeService _bulkPostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _bulkPostcodeService = new BulkPostcodeService();
            await _bulkPostcodeService.MakeRequestAsync("T4f9fss, Mffh5N, EXL");
        }

        [Test]
        public void ResultIsNull_InJsonResponse()
        {
            Assert.That(_bulkPostcodeService.ResponseContent["result"][0]["result"], Is.Empty);
        }

        [Test]
        public void ObjectStatusIs400()
        {
            Assert.That(_bulkPostcodeService.ResponseObject.result[0].result, Is.Null);
        }
    }
}
