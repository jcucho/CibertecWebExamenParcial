using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/StudentGrade")]
    public class StudentGradeController : BaseController
    {
        public StudentGradeController(IUnitOfWork unit) : base(unit)
        {
                
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.StudentGrades.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getById(int id)
        {
            return Ok(_unit.StudentGrades.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentGrade studentGrade)
        {
            if (ModelState.IsValid)
                return Ok(_unit.StudentGrades.Insert(studentGrade));
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] StudentGrade studentGrade)
        {
            if (ModelState.IsValid && _unit.StudentGrades.Update(studentGrade))
                return Ok(new { Message = "The studentGrade is updated" });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] StudentGrade studentGrade)
        {
            if (studentGrade.EnrollmentID > 0)
                return Ok(_unit.StudentGrades.Delete(studentGrade));
            return BadRequest(new { Message = "Incorrect data" });
        }
    }
}