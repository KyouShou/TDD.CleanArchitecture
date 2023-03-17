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
        ApplicationForm _applicationForm;

        [SetUp]
        public void Setup()
        {
            _applicationForm = new ApplicationForm(12345L, 98765L);
        }

        [TearDown]
        public void End()
        {
            _applicationForm = null;
        }

        [Test]
        public void All_Ok()
        {
            Mock<IStudentRepository> mockRepository = GenerateMockRepositoryReturnsOneStudent();

            ApplyScholarshipService applyScholarshipService = new ApplyScholarshipService(mockRepository.Object);

            applyScholarshipService.Apply(_applicationForm);
        }

        private static Mock<IStudentRepository> GenerateMockRepositoryReturnsOneStudent()
        {
            var mockRepository = new Mock<IStudentRepository>();
            var fakeList = new List<Student>();
            fakeList.Add(new Student()
            {
                Id = 1,
                Name = "hello"
            });
            mockRepository.Setup(m => m.Find(12345L)).Returns(fakeList);
            return mockRepository;
        }

        [Test]
        public void When_Student_Not_Exist_Then_StudentNotExistException()
        {
            Mock<IStudentRepository> mockStudentRepository = GenerateRepositoryReturnsNoStudent();

            ApplyScholarshipService applyScholarshipService = new ApplyScholarshipService(mockStudentRepository.Object);

            Assert.Throws<StudentNotExistException>(() => applyScholarshipService.Apply(_applicationForm));
        }

        private static Mock<IStudentRepository> GenerateRepositoryReturnsNoStudent()
        {
            var mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(m => m.Find(12345L)).Returns(new List<Student>());
            return mockStudentRepository;
        }
    }
}
