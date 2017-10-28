using Cibertec.Mocked;
using Cibertec.Models;
using Cibertec.UnitOfWork;
using Cibertec.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cibertec.WebApi.Tests
{
    public class PersonControllerTests
    {
        private readonly PersonController _personController;
        private readonly IUnitOfWork _uniMocked;

        public PersonControllerTests()
        {
            var unitMocked = new UnitOfWorkMocked();
            _uniMocked = unitMocked.GetInstance();
            _personController = new PersonController(_uniMocked);
            //_personController = new PersonController(new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString));
        }

        [Fact(DisplayName = "[PersonController] Get List")]
        public void Test_Get_All_Fluent()
        {
            var result = _personController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Person>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[PersonController] Insert")]
        public void Insert_Person_Test()
        {
            var person = new Person
            {
                PersonID = 101,
                LastName = "Cucho",
                FirstName = "Juan",
                HireDate = DateTime.Now,
                EnrollmentDate = DateTime.Now
            };

            var result = _personController.Post(person) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(101);
        }

        [Fact(DisplayName = "[PersonController] Update")]
        public void Update_Customer_Test()
        {
            var person = new Person
            {
                PersonID = 1,
                LastName = "Cucho",
                FirstName = "Juan",
                HireDate = DateTime.Now,
                EnrollmentDate = DateTime.Now
            };

            var result = _personController.Put(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value?.GetType().GetProperty("Message").GetValue(result.Value);
            model.Should().Be("The person is updated");

            var currentPerson = _uniMocked.Persons.GetById(1);
            currentPerson.Should().NotBeNull();
            currentPerson.PersonID.Should().Be(person.PersonID);
            currentPerson.LastName.Should().Be(person.LastName);
            currentPerson.HireDate.Should().Be(person.HireDate);
            currentPerson.EnrollmentDate.Should().Be(person.EnrollmentDate);
        }

        [Fact(DisplayName = "[PersonController] Delete")]
        public void Delete_Customer_Test()
        {
            var person = new Person
            {
                PersonID = 1
            };

            var result = _personController.Delete(person) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

            var currentCustomer = _uniMocked.Persons.GetById(1);
            currentCustomer.Should().BeNull();
        }
    }
}
