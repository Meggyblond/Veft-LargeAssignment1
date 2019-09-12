using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;
using TechnicalRadiation.WebApi.Attributes;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private NewsService _newsService = new NewsService();
        
        [Route("")]
        [HttpGet]
        public IActionResult GetAllNews([FromQuery] int pageSize = 25,[FromQuery] int pageNumber = 1)
        {
            var news = _newsService.GetAllNews(pageSize, pageNumber);
            return Ok(news);
        }

        [Route("{newsItemId:int}", Name = "GetNewsItemById")]
        [HttpGet]
        public IActionResult GetNewsItemById(int newsItemId)
        {
            var news = _newsService.GetNewsItemById(newsItemId);
            return Ok(news);
        }

        [Authorize]
        [Route("")]
        [HttpPost]
        public IActionResult CreateNews([FromBody] NewsItemInputModel body)
        {
            if(!ModelState.IsValid)
            {
                throw new ModelFormatException("Model not properly formatted");
            }
            var entity = _newsService.CreateNews(body);
            return CreatedAtRoute("GetNewsItemById", new { newsItemId = entity.Id }, null);
        }

        [Authorize]
        [Route("{newsItemId:int}", Name = "UpdateNews")]
        [HttpPut]
        public IActionResult UpdateNews([FromBody] NewsItemInputModel body, int newsItemId)
        {
            if(!ModelState.IsValid)
            {
                throw new ModelFormatException("Model not properly formatted");
            }
            _newsService.UpdateNews(body, newsItemId);
            return NoContent();
        }
        
        [Authorize]
        [Route("{newsItemId:int}", Name = "DeleteNews")]
        [HttpDelete]
        public IActionResult DeleteNews(int newsItemId)
        {
            _newsService.DeleteNews(newsItemId);
            return NoContent();
        }
    }
}