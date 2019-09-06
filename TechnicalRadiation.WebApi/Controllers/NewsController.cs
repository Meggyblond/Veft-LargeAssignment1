using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAllNews([FromQuery(Name = "pageSize")] int pageSize = 25)
        {
            return Ok(_newsService.GetAllNews(pageSize));
        }
        [Route("{id:int}", Name = "GetNewsItemById")]
        [HttpGet]
        public IActionResult GetNewsItemById(int id)
        {
            return Ok(_newsService.GetNewsItemById(id));
        }
    }
}