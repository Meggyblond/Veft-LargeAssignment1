using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
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

        [Route("")]
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel body)
        {
            if(!ModelState.IsValid) {return BadRequest("Model not properly formatted");}
            var entity = _authorsService.CreateAuthor(body);
            return CreatedAtRoute("GetAuthorById", new { id = entity.Id }, null);
        }

        [Route("{id:int}", Name = "UpdateAuthor")]
        [HttpPut]
        public IActionResult UpdateAuthor([FromBody] AuthorInputModel body, int id)
        {
            if(!ModelState.IsValid) { return BadRequest("Model not properly formatted");}
            _authorsService.UpdateAuthor(body, id);
            return NoContent();
        }

        [Route("{id:int}", Name = "DeleteAuthor")]
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            _authorsService.DeleteAuthor(id);
            return NoContent();
        }
    }
}