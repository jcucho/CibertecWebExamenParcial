using Cibertec.WebApi.Controllers;
using Xunit;
using Cibertec.Repositories.Dapper.School;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cibertec.Models;
using FluentAssertions;

namespace Cibertec.WebApi.Tests
{
    public class CourseControllerTests
    {
        private readonly CourseController _courseController;
        public CourseControllerTests()
        {
            _courseController = new CourseController(new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString));
        }

        [Fact(DisplayName = "[CourseController] Get List")]
        public void Test_Get_All()
        {
            var result = _courseController.GetList() as OkObjectResult;
            Assert.True(result != null);
            Assert.True(result.Value != null);
            var model = result.Value as List<Course>;
            Assert.True(model.Count > 0);
        }

        [Fact(DisplayName = "[CourseController] Get List All_Fluent")]
        public void Test_Get_All_Fluent()
        {
            var result = _courseController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Course>;
            model.Count.Should().BeGreaterThan(0);
        }
    }
}
