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
        static List<Category> _categories = new List<Category> {
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
            return Ok(_categories);
        }

        /// <summary>
        /// This is an getCategoryById method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public IActionResult GetById(Guid id)
        { 
            Category category = new Category();
            bool isValid = false;
            foreach(Category currCategory in _categories)
            {
                if (currCategory.Id.Equals(id))
                {
                    category = currCategory;
                    isValid = true;
                }
            }
            if (!isValid)
            {
                return NotFound();
            }
            return Ok(category);
        }

        /// <summary>
        /// This is an deleteCategoryById method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            foreach(Category currCategory in _categories)
            {
                if (currCategory.Id.Equals(id))
                {
                    _categories.Remove(currCategory);
                }
            }
            return Ok(id);
        }

        /// <summary>
        /// This is an CreateCategory method.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            _categories.Add(category);
            return Ok("Category added.");
        }
    }
}

