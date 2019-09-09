using System.Collections.Generic;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class AuthorsService
    {
        private AuthorsRepository _authorsRepo = new AuthorsRepository();
        public IEnumerable<AuthorDto> GetAllAuthors() 
        {
            return _authorsRepo.GetAllAuthors();
        }
        public AuthorDto GetAuthorById(int id)
        {
            return _authorsRepo.GetAuthorById(id);
        }
        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
            return _authorsRepo.GetNewsByAuthorId(id);
        }
    }
}