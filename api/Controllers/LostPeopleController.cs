using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/lost")]
    public class LostPeopleController: ControllerBase
    {
        private readonly ILostPerson _lostPerson;

        public LostPeopleController(ILostPerson lostPerson)
        {
            _lostPerson = lostPerson;
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetAll()
        {
            var lost = _lostPerson.GetAllLost();
            return Ok(lost);
        }
    }
}