using System;
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

        [HttpGet("getAll")]
        [Authorize]
        public ActionResult GetAll()
        {
            var lost = _lostPerson.GetAllLost();
            return Ok(lost);
        }

        [HttpGet]
        public ActionResult GetWithLimits([FromQuery] string skip, [FromQuery] string take)
        {
            var lost = _lostPerson.GetSelected(Int32.Parse(take), Int32.Parse(skip));
            return Ok(lost);
        }
    }
}