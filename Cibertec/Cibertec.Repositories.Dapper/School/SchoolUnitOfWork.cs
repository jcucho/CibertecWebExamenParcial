using Cibertec.Repositories.School;
using Cibertec.UnitOfWork;

namespace Cibertec.Repositories.Dapper.School
{
    public class SchoolUnitOfWork : IUnitOfWork
    {
        public SchoolUnitOfWork(string connectioString)
        {
            Courses = new CourseRepository(connectioString);
            Departments = new DepartmentRepository(connectioString);
            Persons = new PersonRepository(connectioString);
            StudentGrades = new StudentGradeRepository(connectioString);
            Users = new UserRepository(connectioString);
        }

        public ICourseRepository Courses { get; private set; }

        public IDepartmentRepository Departments { get; private set; }

        public IPersonRepository Persons { get; private set; }

        public IStudentGradeRepository StudentGrades { get; private set; }

        public IUserRepository Users { get; private set; }
    }
}
