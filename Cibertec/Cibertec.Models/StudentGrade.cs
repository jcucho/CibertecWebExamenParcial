using Dapper.Contrib.Extensions;

namespace Cibertec.Models
{
    public class StudentGrade
    {
        [ExplicitKey]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public decimal Grade { get; set; }
    }
}
