using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD.CleanArchitecture.Controllers;
using TDD.CleanArchitecture.Exceptions;
using TDD.CleanArchitecture.Service;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;

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
        public void Student_Not_Exists()
        {
            IActionResult response = Assume_Controller_Catch_Exception(new StudentNotExistException());

            var statusCode = ((ContentResult)response).StatusCode;
            var content = ((ContentResult)response).Content;

            Assert.AreEqual(400, statusCode);
            Assert.AreEqual("987", content);
        }    

        [Test]
        public void Scholarship_Not_Exists()
        {
            IActionResult response = Assume_Controller_Catch_Exception(new ScholarshipNotExistException());

            var statusCode = ((ContentResult)response).StatusCode;
            var content = ((ContentResult)response).Content;

            Assert.AreEqual(400, statusCode);
            Assert.AreEqual("369", content);
        }

        [Test]
        public void Data_Access_Error()
        {
            IActionResult response = Assume_Controller_Catch_Exception(new DataAccessErrorException());

            var statusCode = ((ContentResult)response).StatusCode;
            var content = ((ContentResult)response).Content;

            Assert.AreEqual(500, statusCode);
            Assert.AreEqual("666", content);
        }

        [Test]
        public void Unknown_Error()
        {
            IActionResult response = Assume_Controller_Catch_Exception(new SystemException());

            var statusCode = ((ContentResult)response).StatusCode;
            var content = ((ContentResult)response).Content;

            Assert.AreEqual(500, statusCode);
            Assert.AreEqual("200", content);
        }

        private static IActionResult Assume_Controller_Catch_Exception(Exception exception)
        {
            ApplicationForm applicationForm = new ApplicationForm(9527L, 55688L);

            var applyScholarshipService = new Mock<IApplyScholarshipService>();
            applyScholarshipService.Setup(m => m.Apply(applicationForm)).Throws(exception);

            var controller = new ScholarshipController(applyScholarshipService.Object);
            var response = controller.Apply(applicationForm);
            return response;
        }
    }
}
