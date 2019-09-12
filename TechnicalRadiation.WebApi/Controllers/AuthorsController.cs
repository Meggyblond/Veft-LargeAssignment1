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
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService = new AuthorsService();

        [Route("")]
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorsService.GetAllAuthors();
            return Ok(authors);
        }

        [Route("{authorId:int}", Name = "GetAuthorById")]
        [HttpGet]
        public IActionResult GetAuthorById(int authorId)
        {
            var author = _authorsService.GetAuthorById(authorId);
            return Ok(author);
        }

        [Route("{authorId:int}/newsitems", Name = "GetNewsByAuthorId")]
        [HttpGet]
        public IActionResult GetNewsByAuthorId(int authorId)
        {
            var news = _authorsService.GetNewsByAuthorId(authorId);
            return Ok(news);
        }

        [Authorize]
        [Route("")]
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel body)
        {
            if(!ModelState.IsValid)
            {
                throw new ModelFormatException("Model not properly formatted");
            }
            var entity = _authorsService.CreateAuthor(body);
            return CreatedAtRoute("GetAuthorById", new { authorId = entity.Id }, null);
        }

        [Authorize]
        [Route("{authorId:int}", Name = "UpdateAuthor")]
        [HttpPut]
        public IActionResult UpdateAuthor([FromBody] AuthorInputModel body, int authorId)
        {
            if(!ModelState.IsValid)
            {
                throw new ModelFormatException("Model not properly formatted");
            }
            _authorsService.UpdateAuthor(body, authorId);
            return NoContent();
        }

        [Authorize]
        [Route("{authorId:int}", Name = "DeleteAuthor")]
        [HttpDelete]
        public IActionResult DeleteAuthor(int authorId)
        {
            _authorsService.DeleteAuthor(authorId);
            return NoContent();
        }
        
        [Authorize]
        [Route("{authorId:int}/newsItems/{newsItemid:int}")]
        [HttpPost]
        public IActionResult LinkAuthorToNewsItem(int authorId, int newsItemid)
        {
            _authorsService.LinkAuthorToNewsItem(authorId, newsItemid);
            return NoContent();
        }
    }
}