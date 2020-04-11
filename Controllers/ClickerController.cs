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

        //Get ClickerByRelatedInterest
        [HttpGet("{interestString}/interest")]
        public IActionResult GetClickerByInterest(string interestString)
        {
            var outcome = _repository.GetClickersByInterest(interestString);
            if (outcome.Count > 0)
            {
                return Ok(outcome);
            }
            return NotFound("Sorry Bruh");
        }

        //Get ClickerByServices
        [HttpGet("{serviceString}/service")]
        public IActionResult GetClinkersByServices(string serviceString)
        {
            var outcome = _repository.GetClickersByService(serviceString);
            if (outcome.Count > 0)
            {
                return Ok(outcome);
            }
            return NotFound("Sorry Bruh");
        }

        //Add Homies and Enemies 
        [HttpPost("clicker/{clickerId}/homie/{homieId}")]
        public IActionResult AddHomie(int clickerId, int homieId)
        {
            var clicker = _repository.AddHomies(clickerId, homieId);
            return Ok(clicker);
        }

        [HttpPost("clicker/{clickerId}/enemy/{enemyId}")]
        public IActionResult AddEnemy(int clickerId, int enemyId)
        {
            var clicker = _repository.AddEnemy(clickerId, enemyId);
            return Ok(clicker);
        }

    }
}