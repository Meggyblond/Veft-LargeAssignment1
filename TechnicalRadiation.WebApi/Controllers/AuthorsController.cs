using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService = new AuthorsService();
        // GET api/values
        [Route("")]
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            return Ok(_authorsService.GetAllAuthors());
        }

        [Route("{id:int}", Name = "GetAuthorById")]
        [HttpGet]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_authorsService.GetAuthorById(id));
        }

        [Route("{id:int}/newsitems", Name = "GetNewsByAuthorId")]
        [HttpGet]
        public IActionResult GetNewsByAuthorId(int id)
        {
            return Ok(_authorsService.GetNewsByAuthorId(id));
        }
    }
}