using Dapper.Contrib.Extensions;

namespace Cibertec.Models
{
    public class Course
    {
        [ExplicitKey]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}
