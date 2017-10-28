using Cibertec.Models;
using Cibertec.Repositories.School;

namespace Cibertec.Repositories.Dapper.School
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
