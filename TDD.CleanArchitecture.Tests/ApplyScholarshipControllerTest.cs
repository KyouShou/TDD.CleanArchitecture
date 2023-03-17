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
            ApplicationForm applicationForm = new ApplicationForm(9527L, 55688L);

            var applScholarshipService = new Mock<IApplScholarshipService>();
            applScholarshipService.Setup(m => m.Apply(applicationForm)).Throws(new StudentNotExistException());


            var controller = new ScholarshipController(applScholarshipService.Object);
            var response = controller.Apply(applicationForm);

            var statusCode = ((ContentResult)response).StatusCode;
            var content = ((ContentResult)response).Content;

            Assert.AreEqual(400, statusCode);
            Assert.AreEqual("987", content);
        }

        [Test]
        public void Scholarship_Not_Exists()
        {
            ApplicationForm applicationForm = new ApplicationForm(9527L, 55688L);

            var applScholarshipService = new Mock<IApplScholarshipService>();
            applScholarshipService.Setup(m => m.Apply(applicationForm)).Throws(new ScholarshipNotExistException());

            var controller = new ScholarshipController(applScholarshipService.Object);
            var response = controller.Apply(applicationForm);

            var statusCode = ((ContentResult)response).StatusCode;
            var content = ((ContentResult)response).Content;

            Assert.AreEqual(400, statusCode);
            Assert.AreEqual("369", content);
        }
    }
}
