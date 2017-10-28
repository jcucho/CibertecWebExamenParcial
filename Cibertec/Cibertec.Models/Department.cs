using Dapper.Contrib.Extensions;
using System;

namespace Cibertec.Models
{
    public class Department
    {
        [ExplicitKey]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int Administrator { get; set; }
    }
}
