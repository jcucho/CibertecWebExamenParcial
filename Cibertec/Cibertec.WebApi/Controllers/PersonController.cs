using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : BaseController
    {
        public PersonController(IUnitOfWork unit) : base(unit)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Persons.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getById(int id)
        {
            return Ok(_unit.Persons.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Persons.Insert(person));
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (ModelState.IsValid && _unit.Persons.Update(person))
                return Ok(new { Message = "The person is updated" });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Person person)
        {
            if (person.PersonID > 0)
                return Ok(_unit.Persons.Delete(person));
            return BadRequest(new { Message = "Incorrect data" });
        }
    }
}