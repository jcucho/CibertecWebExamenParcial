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
        public void Test_Get_List()
        {
            var result = _studentGradeController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<StudentGrade>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[StudentGradeController] Insert")]
        public void Test_StudentGrade_Insert()
        {
            var studentGrade = GetNewStudentGrade();
            var result = _studentGradeController.Post(studentGrade);
            result.Should().NotBeNull();            
        }

        [Fact(DisplayName = "[StudentGradeController] Delete")]
        public void Test_StudentGrade_Delete()
        {
            var studentGrade = GetDeleteStudentGrade();
            var result = _studentGradeController.Delete(studentGrade);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[StudentGradeController] Update")]
        public void Test_StudentGrade_Update()
        {
            var studentGrade = GetUpdateStudentGrade();
            var result = _studentGradeController.Put(studentGrade);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[StudentGradeController] Get Id")]
        public void Test_StudentGrade_GetId()
        {
            var result = _studentGradeController.getById(39);
            result.Should().NotBeNull();
        }

        private StudentGrade GetUpdateStudentGrade()
        {
            return new StudentGrade
            {
                EnrollmentID = 39,
                CourseID = 1050,
                StudentID = 30,
                Grade = 4
            };
        }

        private StudentGrade GetDeleteStudentGrade()
        {
            return new StudentGrade
            {
                EnrollmentID = 40,
                CourseID = 1061,
                StudentID = 30,
                Grade = 4
            };
        }

        private StudentGrade GetNewStudentGrade()
        {
            return new StudentGrade
            {
                CourseID = 1061,
                StudentID = 30,               
                Grade= 4
            };
        }
    }
}
