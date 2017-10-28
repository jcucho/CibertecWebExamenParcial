using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;


namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    public class BaseController : Controller
    {
        protected IUnitOfWork _unit;
        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
    }
}