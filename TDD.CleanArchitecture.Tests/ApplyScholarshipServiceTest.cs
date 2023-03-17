using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;
using System;
using TDD.CleanArchitecture.Controllers;
using TDD.CleanArchitecture.Exceptions;
using TDD.CleanArchitecture.Models;
using TDD.CleanArchitecture.Repository;
using TDD.CleanArchitecture.Service;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;

namespace TDD.CleanArchitecture.Tests
{
    internal class ApplyScholarshipServiceTest
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
        public void All_Ok()
        {
            var mockRepository = new Mock<IStudentRepository>();
            var fakeList = new List<Student>();
            fakeList.Add(new Student()
            {
                Id = 1,
                Name = "hello"
            });
            mockRepository.Setup(m => m.Find(12345L)).Returns(fakeList);

            ApplyScholarshipService applyScholarshipService = new ApplyScholarshipService(mockRepository.Object);
            ApplicationForm applicationForm = new ApplicationForm(12345L, 98765L);

            applyScholarshipService.Apply(applicationForm);
        }

        [Test]
        public void When_Student_Not_Exist_Then_987()
        {
            var mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(m => m.Find(12345L)).Returns(new List<Student>());

            ApplyScholarshipService applyScholarshipService = new ApplyScholarshipService(mockStudentRepository.Object);

            var applicationForm = new ApplicationForm(12345L, 98765L);

            Assert.Throws<StudentNotExistException>(() => applyScholarshipService.Apply(applicationForm));
        }
    }
}
