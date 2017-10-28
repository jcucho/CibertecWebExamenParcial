using Cibertec.WebApi.Controllers;
using Xunit;
using Cibertec.Repositories.Dapper.School;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cibertec.Models;
using FluentAssertions;
using System;

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
        public void Test_Get_List()
        {
            var result = _departmentController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Department>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[DepartmentController] Insert")]
        public void Test_Department_Insert()
        {
            var department = GetInsertDepartment();
            var result = _departmentController.Post(department);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[DepartmentController] Update")]
        public void Test_Department_Update()
        {
            var department = GetUpdateDepartment();
            var result = _departmentController.Put(department);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[DepartmentController] Delete")]
        public void Test_Department_Delete()
        {
            var department = GetDeleteDepartment();
            var result = _departmentController.Delete(department);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[DepartmentController] Get Id")]
        public void Test_Department_GetId()
        {
            var result = _departmentController.getById(7);
            result.Should().NotBeNull();
        }

        private Department GetDeleteDepartment()
        {
            return new Department
            {
                DepartmentID = 8,
                Name = "Logistica",
                Budget = 1000,
                StartDate = DateTime.Now,
                Administrator = 2
            };
        }

        private Department GetUpdateDepartment()
        {
            return new Department
            {
                DepartmentID = 8,
                Name = "Logistica",
                Budget = 1000,
                StartDate = DateTime.Now,
                Administrator = 2
            };
        }

        private Department GetInsertDepartment()
        {
            return new Department
            {
                DepartmentID = 8,
                Name = "Sistemas",
                Budget = 1000,
                StartDate = DateTime.Now,
                Administrator = 2
            };
        }

    }
}
