using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApiV2.Controllers.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        static List<Category> categories = new List<Category> {
            new Category { Id = Guid.NewGuid(), Name = "Lab"},
            new Category { Id = Guid.NewGuid(), Name = "Course"},
            new Category { Id = Guid.NewGuid(), Name = "Seminary"}
        };

        /// <summary>
        /// This is an getAllCategories method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GetCategories method was called.");
        }

        /// <summary>
        /// This is an getCategoryById method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok("GetCategoryById method was called.");
        }

        /// <summary>
        /// This is an deleteCategoryById method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return Ok(id);
        }
    }
}

