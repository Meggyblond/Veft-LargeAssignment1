using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class AuthorsService
    {
        private AuthorsRepository _authorsRepo = new AuthorsRepository();
        private NewsService _newsService = new NewsService();
        public IEnumerable<AuthorDto> GetAllAuthors() 
        {
            var authors = _authorsRepo.GetAllAuthors().ToList();
            for(int i = 0; i < authors.Count(); i++) 
            {
                var obj = new { href = $"api/authors/{authors[i].Id}" };
                var urlObj = new { href = $"api/authors/{authors[i].Id}/newsItems" };
                authors[i].Links.AddReference("self", obj);
                authors[i].Links.AddReference("edit", obj);
                authors[i].Links.AddReference("delete", obj);
                authors[i].Links.AddReference("newsItems", urlObj);

                List<object> listOfNewsObj = new List<object>();
                var news = GetNewsByAuthorId(authors[i].Id).ToList();
                for(int j = 0; j < news.Count(); j++)
                {
                    var newsObj = new { href = $"api/{news[j].Id}" };
                    listOfNewsObj.Add(newsObj);
                }
                authors[i].Links.AddListReference("newsItemsDetailed", listOfNewsObj);

            }
            return authors;
        }
        public AuthorDetailDto GetAuthorById(int authorId)
        {
            var author = _authorsRepo.GetAuthorById(authorId);
            if(author == null)
            {
                throw new ResourceNotFoundException($"Author with id: {authorId} was not found");
            }
            var obj = new { href = $"api/authors/{authorId}" };
            var urlObj = new { href = $"api/authors/{authorId}/newsItems" };

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
            var author = _authorsRepo.GetAuthorById(authorId);
            var news = _authorsRepo.GetNewsByAuthorId(authorId).ToList();
            for(int i = 0; i < news.Count(); i++)
            {
                var obj = new { href = $"api/{news[i].Id}"};
                news[i].Links.AddReference("self", obj);
                news[i].Links.AddReference("edit", obj);
                news[i].Links.AddReference("delete", obj);

                var authorsObjectList = _newsService.getAuthorsObjectByNewsId(news[i].Id);
                news[i].Links.AddListReference("authors", authorsObjectList);

                var categoriesObjectList = _newsService.getCategoriesObjectByNewsId(news[i].Id);
                news[i].Links.AddListReference("categories", categoriesObjectList);
            }
            
            return news;
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