using Moq;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TDD.CleanArchitecture.Tests
{
    internal class ApplyScholarshipControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void End()
        {
        }

        [Test]
        public void Student_Not_Exist()
        {
            ApplicationForm applicationForm = new ApplicationForm(9527L, 55688L);
            var applyScholarshipService = Mock.Of<IApplScholarshipService>();
            Mock.Get(applyScholarshipService).Setup(s => s.Apply(applicationForm)).Throws(new StudentNotExistException("ANY_MESSAGE"));
            var json = JsonConvert.SerializeObject(applicationForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "/scholarship/apply") { Content = content };
            var response = _client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<ApiResponse<int>>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(987, result.Data);
        }
    }
}
