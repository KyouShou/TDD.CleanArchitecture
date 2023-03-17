using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TDD.CleanArchitecture.Controllers;
using TDD.CleanArchitecture.Exceptions;
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
            ApplyScholarshipService applyScholarshipService = new ApplyScholarshipService();
            ApplicationForm applicationForm = new ApplicationForm(12345L, 98765L);

            applyScholarshipService.Apply(applicationForm);
        }
    }
}
