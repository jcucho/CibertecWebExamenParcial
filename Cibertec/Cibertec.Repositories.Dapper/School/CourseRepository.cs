using Cibertec.Models;
using Cibertec.Repositories.School;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Dapper.School
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
