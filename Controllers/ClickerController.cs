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

        //Get all Clickers
        [HttpGet]
        public IActionResult GetAllClickers()
        {
            var allClickers = _repository.GetClickers();

            return Ok(allClickers);
        }

        //Get ClickerById
        [HttpGet("{id}")]
        public IActionResult GetClickerById(int id )
        {
            var clickerIWant = _repository.GetClickerById(id);
            if (clickerIWant == null) return NotFound("They Gone Bruh");
            return Ok(clickerIWant);
        }
    }
}