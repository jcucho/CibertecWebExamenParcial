using Cibertec.Models;
using Cibertec.UnitOfWork;
using Moq;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Linq;
using Cibertec.Repositories.School;

namespace Cibertec.Mocked
{
    public class UnitOfWorkMocked
    {
        private List<Person> _persons;

        public UnitOfWorkMocked()
        {
            _persons = Persons();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Persons).Returns(PersonRepositoryMocked());
            return mocked.Object;
        }

        private IPersonRepository PersonRepositoryMocked()
        {
            var customerMocked = new Mock<IPersonRepository>();
            customerMocked.Setup(c => c.GetList()).Returns(_persons);
            customerMocked.Setup(c => c.Insert(It.IsAny<Person>())).Callback<Person>((c) => _persons.Add(c)).Returns<Person>(c => c.PersonID);
            customerMocked.Setup(c => c.Delete(It.IsAny<Person>())).Callback<Person>((c) => _persons.RemoveAll(cus => cus.PersonID == c.PersonID)).Returns(true);
            customerMocked.Setup(c => c.Update(It.IsAny<Person>())).Callback<Person>((c) => { _persons.RemoveAll(cus => cus.PersonID == c.PersonID); _persons.Add(c); }).Returns(true);
            customerMocked.Setup(c => c.GetById(It.IsAny<int>())).Returns((int id) => _persons.FirstOrDefault(cus => cus.PersonID == id));
            return customerMocked.Object;
        }

        private List<Person> Persons()
        {
            var fixture = new Fixture();
            var customers = fixture.CreateMany<Person>(50).ToList();
            for (int i = 0; i < 50; i++)
            {
                customers[i].PersonID = i + 1;
            }
            return customers;
        }
    }
}
