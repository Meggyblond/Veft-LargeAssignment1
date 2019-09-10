using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private NewsService _newsService = new NewsService();
        // GET api/values
        [Route("")]
        [HttpGet]
        public IActionResult GetAllNews([FromQuery] int pageSize = 25,[FromQuery] int pageNumber = 1)
        {
            return Ok(_newsService.GetAllNews(pageSize, pageNumber));
        }
        [Route("{id:int}", Name = "GetNewsItemById")]
        [HttpGet]
        public IActionResult GetNewsItemById(int id)
        {
            return Ok(_newsService.GetNewsItemById(id));
        }
        [Route("")]
        [HttpPost]
        public IActionResult CreateNews([FromBody] NewsItemInputModel body)
        {
            if(!ModelState.IsValid) {return BadRequest("Model is not properly formatted");}
            var entity = _newsService.CreateNews(body);
            return CreatedAtRoute("GetNewsItemById", new { id = entity.Id }, null);
        }
        [Route("{id:int}", Name = "UpdateNews")]
        [HttpPut]
        public IActionResult UpdateNews([FromBody] NewsItemInputModel body, int id)
        {
            if(!ModelState.IsValid) {return BadRequest("Model is not properly formatted");}
            _newsService.UpdateNews(body, id);
            return NoContent();
        }

    }
}