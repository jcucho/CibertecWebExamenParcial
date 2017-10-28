using Cibertec.WebApi.Controllers;
using Xunit;
using Cibertec.Repositories.Dapper.School;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cibertec.Models;
using FluentAssertions;

namespace Cibertec.WebApi.Tests
{
    public class DepartmentControllerTests
    {
        private readonly DepartmentController _departmentController;
        public DepartmentControllerTests()
        {
            _departmentController = new DepartmentController(new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString));
        }

        [Fact(DisplayName = "[DepartmentController] Get List")]
        public void Test_Get_All()
        {
            var result = _departmentController.GetList() as OkObjectResult;
            Assert.True(result != null);
            Assert.True(result.Value != null);
            var model = result.Value as List<Department>;
            Assert.True(model.Count > 0);
        }

        [Fact(DisplayName = "[DepartmentController] Get List All_Fluent")]
        public void Test_Get_All_Fluent()
        {
            var result = _departmentController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Department>;
            model.Count.Should().BeGreaterThan(0);
        }
    }
}
