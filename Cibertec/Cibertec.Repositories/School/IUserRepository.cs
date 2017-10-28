using Cibertec.Models;

namespace Cibertec.Repositories.School
{
    public interface IUserRepository : IRepository<User>
    {
        User ValidaterUser(string email, string password);
    }
}

