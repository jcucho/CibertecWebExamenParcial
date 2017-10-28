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
    public class PersonControllerTests
    {
        private readonly PersonController _personController;

        public PersonControllerTests()
        {
            _personController = new PersonController(new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString));
        }

        [Fact(DisplayName = "[PersonController] Get List")]
        public void Get_List()
        {
            var result = _personController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Person>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[PersonController] Insert")]
        public void Test_Person_Insert()
        {
            var person = GetInsertPerson();
            var result = _personController.Post(person);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[PersonController] Update")]
        public void Test_Person_Update()
        {
            var person = GetUpdatePerson();
            var result = _personController.Put(person);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[PersonController] Delete")]
        public void Test_Person_Delete()
        {
            var person = GetDeletePerson();
            var result = _personController.Delete(person);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "[PersonController] Get Id")]
        public void Test_Person_GetId()
        {
            var result = _personController.getById(1);
            result.Should().NotBeNull();
        }

        private Person GetInsertPerson()
        {
            return new Person
            {
                PersonID = 35,
                LastName = "Juan",
                FirstName = "Cucho",
                HireDate = DateTime.Now,
                EnrollmentDate = DateTime.Now
            };
        }

        private Person GetUpdatePerson()
        {
            return new Person
            {
                PersonID = 34,
                LastName = "Juan",
                FirstName = "Cucho",
                HireDate = DateTime.Now,
                EnrollmentDate = DateTime.Now
            };
        }

        private Person GetDeletePerson()
        {
            return new Person
            {
                PersonID = 34,
                LastName = "Van Houten",
                FirstName = "Roger",
                HireDate = DateTime.Now,
                EnrollmentDate = DateTime.Now
            };
        }
    }
}
