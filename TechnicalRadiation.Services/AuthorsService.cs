using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class AuthorsService
    {
        private AuthorsRepository _authorsRepo = new AuthorsRepository();
        public IEnumerable<AuthorDto> GetAllAuthors() 
        {
            var authors = _authorsRepo.GetAllAuthors().ToList();
            for(int i = 0; i < authors.Count(); i++) 
            {
                var obj = new { href = $"api/{authors[i].Id}" };
                authors[i].Links.AddReference("self", obj);
                authors[i].Links.AddReference("edit", obj);
                authors[i].Links.AddReference("delete", obj);
            }
            return authors;
        }
        public AuthorDetailDto GetAuthorById(int authorId)
        {
            var author = _authorsRepo.GetAuthorById(authorId);
            var obj = new { href = $"api/{authorId}" };
            var urlObj = new { href = $"api/{authorId}/newsItems" };

            author.Links.AddReference("self", obj);
            author.Links.AddReference("edit", obj);
            author.Links.AddReference("delete", obj);
            author.Links.AddReference("newsItems", urlObj);
            
            List<object> listOfNewsObj = new List<object>();
            var news = GetNewsByAuthorId(authorId).ToList();
            for(int i = 0; i < news.Count(); i++)
            {
                var newsObj = new { href = $"api/{news[i].Id}" };
                listOfNewsObj.Add(newsObj);
            }
            author.Links.AddListReference("newsItemsDetailed", listOfNewsObj);
            return author;
        }
        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int authorId)
        {
            return _authorsRepo.GetNewsByAuthorId(authorId);
        }
        public AuthorDto CreateAuthor(AuthorInputModel author)
        {
            return _authorsRepo.CreateAuthor(author);
        }
        public void UpdateAuthor(AuthorInputModel author, int id)
        {
            _authorsRepo.UpdateAuthor(author, id);
        }
        public void DeleteAuthor(int id)
        {
            _authorsRepo.DeleteAuthor(id);
        }
        public void LinkAuthorToNewsItem(int authorId, int newsId)
        {
            _authorsRepo.LinkAuthorToNewsItem(authorId, newsId);
        }
    }
}