using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private CategoriesService _categoriesService = new CategoriesService();
        // GET api/values
        [Route("")]
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoriesService.GetAllCategories());
        }

        [Route("{id:int}", Name = "GetCategoryById")]
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_categoriesService.GetCategoryById(id));
        }
    }
}