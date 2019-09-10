using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private CategoriesService _categoriesService = new CategoriesService();
        [Route("")]
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoriesService.GetAllCategories());
        }

        [Route("{categoryId:int}", Name = "GetCategoryById")]
        [HttpGet]
        public IActionResult GetCategoryById(int categoryId)
        {
            return Ok(_categoriesService.GetCategoryById(categoryId));
        }

        [Route("")]
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryInputModel body)
        {
            if(!ModelState.IsValid) {return BadRequest("Model is not properly formatted");}
            var entity = _categoriesService.CreateCategory(body);
            return CreatedAtRoute("GetCategoryById", new { id = entity.Id }, null);
        }

        [Route("{id:int}", Name = "UpdateCategory")]
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] CategoryInputModel body, int id)
        {
            if(!ModelState.IsValid) {return BadRequest("Model is not properly formatted");}
            _categoriesService.UpdateCategory(body, id);
            return NoContent();
        }
        
        [Route("{id:int}", Name = "DeleteCategory")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoriesService.DeleteCategory(id);
            return NoContent();
        }

        [Route("{categoryId:int}/newsItems/{newsItemId:int}")]
        [HttpPost]
        public IActionResult LinkAuthorToNewsItem(int newsItemId, int categoryId)
        {
            _categoriesService.LinkNewsItemToCategory(newsItemId, categoryId);
            return NoContent();
        }
    }
}