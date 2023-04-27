using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        //[HttpGet("GetId/{id}")]
        //public IActionResult GetId(Guid id)
        //{
        //    return Ok(id);
        //}

        [HttpGet("{name}")]
        public IActionResult GetId(string name, double param1, double param2)
        {
            double sum = param1 + param2;
            string message = $"Hoola, {name}, the sum of {param1} and {param2} is {sum}";
            return Ok(message);
        }
    }
}

