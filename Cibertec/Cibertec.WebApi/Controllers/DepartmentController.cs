using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Department")]
    public class DepartmentController : BaseController
    {
        public DepartmentController(IUnitOfWork unit) : base(unit)
        {

        }
        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Departments.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getById(int id)
        {
            return Ok(_unit.Departments.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Departments.Insert(department));
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Department department)
        {
            if (ModelState.IsValid && _unit.Departments.Update(department))
                return Ok(new { Message = "The department is updated" });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Department department)
        {
            if (department.DepartmentID > 0)
                return Ok(_unit.Departments.Delete(department));
            return BadRequest(new { Message = "Incorrect data" });
        }
    }
}