using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Carisusa_Dapper_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        public SampleController()
        {
            
        }
        
        [HttpGet("WhoAmI")]
        public IActionResult WhoAmI () 
        {
            return Ok("I am Lawrenz Xavier Carisusa");
        }

        [HttpPost("NiceToMeetYou")]
        public IActionResult WhoNiceToMeetYouAmI (string? yourName) 
        {
            if (string.IsNullOrEmpty(yourName)){
                return BadRequest("YOUR SO ROAD");
            } 
            
            else {
                return Ok($"Nice to meet you {yourName}");
            }
        }


    }
}