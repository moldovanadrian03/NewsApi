using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsApiV2
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementController : ControllerBase
    {
        /// <summary>
        /// This is an getAll method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get method was called.");
        }

        /// <summary>
        /// This is an getElementById method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok("GetById method was called.");
        }

        /// <summary>
        /// This is an deleteElementById method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return Ok(id);
        }

        /// <summary>
        /// This is an createElement method.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Create method was called.");
        }

        /// <summary>
        /// This is an updateElement method.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Update method was called.");
        }
    }
}

