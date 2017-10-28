using Cibertec.Models;
using Cibertec.Repositories.School;


namespace Cibertec.Repositories.Dapper.School
{
    class StudentGradeRepository : Repository<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
