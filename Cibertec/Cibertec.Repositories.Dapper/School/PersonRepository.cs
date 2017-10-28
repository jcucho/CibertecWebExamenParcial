using Cibertec.Models;
using Cibertec.Repositories.School;

namespace Cibertec.Repositories.Dapper.School
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
