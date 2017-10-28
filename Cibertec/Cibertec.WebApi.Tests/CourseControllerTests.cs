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
        public void Test_Get_List()
        {
            var result = _courseController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Course>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[CourseController] Insert")]
        public void Test_Course_Insert()
        {
            var course = GetInsertCourse();
            var result = _courseController.Post(course);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[CourseController] Update")]
        public void Test_Course_Update()
        {
            var course = GetUpdateCourse();
            var result = _courseController.Put(course);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[CourseController] Delete")]
        public void Test_Course_Delete()
        {
            var course = GetDeleteCourse();
            var result = _courseController.Delete(course);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[CourseController] Get Id")]
        public void Test_Course_GetId()
        {
            var result = _courseController.getById(4061);
            result.Should().NotBeNull();
        }

        private Course GetInsertCourse()
        {
            return new Course
            {
                CourseID = 4062,
                Title = ".NET",
                Credits = 2,
                DepartmentID = 4
            };
        }

        private Course GetUpdateCourse()
        {
            return new Course
            {
                CourseID = 4062,
                Title = ".NET VB",
                Credits = 2,
                DepartmentID = 4
            };
        }

        private Course GetDeleteCourse()
        {
            return new Course
            {
                CourseID = 4062,
                Title = ".NET VB",
                Credits = 2,
                DepartmentID = 4
            };
        }
    }
}
