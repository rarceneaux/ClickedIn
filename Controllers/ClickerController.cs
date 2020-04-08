using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClickedIn.DataAccess;
using ClickedIn.Models;

namespace ClickedIn.Controllers
{
    [Route("api/clicker")]
    [ApiController]
    public class ClickerController : ControllerBase
    {
        ClickerRepositiory _repository = new ClickerRepositiory();

        //Joining Social Network//
        [HttpPost]
        public IActionResult AddClicker(Clicker clickerToAdd)
        {
            _repository.AddClicker(clickerToAdd);
            return Created("", clickerToAdd);
        }

        [HttpGet("{Id}/id")]
        public IActionResult GetClinker(int Id)
        {
            return NotFound("In progress");
        }

        [HttpGet("{Interest}/interest")]
        public IActionResult GetClickerByInterest(string Interest)
        {
            var testing = _repository.GetClickerByInterest(Interest);

            return NotFound(testing);
        }

        //Get all Clickers
        [HttpGet]
        public IActionResult GetAllClickers()
        {
            var allClickers = _repository.GetClickers();

            return Ok(allClickers);
        }
    }
}