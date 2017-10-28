using Cibertec.Repositories.School;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }
        IDepartmentRepository Departments { get; }
        IPersonRepository Persons { get; }
        IStudentGradeRepository StudentGrades { get; }
        IUserRepository Users { get; }
    }
}
