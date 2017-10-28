using Dapper.Contrib.Extensions;
using System;

namespace Cibertec.Models
{
    public class Course
    {
        [ExplicitKey]
        public int CourseID { get; set; }
        public String Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}
