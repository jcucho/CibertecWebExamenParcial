using Cibertec.WebApi.Controllers;
using Xunit;
using Cibertec.Repositories.Dapper.School;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cibertec.Models;
using FluentAssertions;

namespace Cibertec.WebApi.Tests
{
    public class StudentGradeControllerTests
    {
        private readonly StudentGradeController _studentGradeController;

        public StudentGradeControllerTests()
        {
            _studentGradeController = new StudentGradeController(new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString));
        }

        [Fact(DisplayName = "[StudentGradeController] Get List")]
        public void Test_Get_All()
        {
            var result = _studentGradeController.GetList() as OkObjectResult;
            Assert.True(result != null);
            Assert.True(result.Value != null);
            var model = result.Value as List<StudentGrade>;
            Assert.True(model.Count > 0);
        }

        [Fact(DisplayName = "[StudentGradeController] Get List All_Fluent")]
        public void Test_Get_All_Fluent()
        {
            var result = _studentGradeController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<StudentGrade>;
            model.Count.Should().BeGreaterThan(0);
        }
    }
}
