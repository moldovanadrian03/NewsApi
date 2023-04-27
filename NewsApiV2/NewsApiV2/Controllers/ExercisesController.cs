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
        static List<string> _users = new List<string>
        {
            "Adi",
            "Andrei",
            "BlaBla",
            "Johnny"
        };

        /// <summary>
        /// This function returns all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_users);
        }

        /// <summary>
        /// This method replace an existing user to the _users list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateUsers(int id, [FromBody] string user)
        {
            if(id < 0 || id > _users.Count)
            {
                return BadRequest("Invalid index.");
            }
            if(user == null)
            {
                return BadRequest("New user cannot be null.");
            }
            _users[id] = user;
            return Ok(_users);
        }

        /// <summary>
        /// This method delete an existing user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if(id < 0 || id > _users.Count)
            {
                return BadRequest("This user does not exist.");
            }
            _users.Remove(_users[id]);
            return Ok(_users);
        }

        [HttpGet("{name}")]
        public IActionResult GetId(string name, double param1, double param2)
        {
            double sum = param1 + param2;
            string message = $"Hoola, {name}, the sum of {param1} and {param2} is {sum}";
            return Ok(message);
        }

        public static double SumOfNumbers(List<double> doubles)
        {
            if(doubles == null || doubles.Count == 0)
            {
                throw new ArgumentException("List cannot be null or empty.");
            }

            double sum = 0;
            foreach (double elem in doubles)
            {
                sum += elem;
            }
            return sum;
        }
    }
}

