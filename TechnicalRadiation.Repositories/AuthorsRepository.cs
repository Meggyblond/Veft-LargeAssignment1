using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class AuthorsRepository
    {
        private NewsRepository _newsRepo = new NewsRepository();
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            return AuthorDataProvider.Authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name
            });
        }
        public AuthorDto GetAuthorById(int id)
        {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if(entity == null) { /* do smth */}
            return new AuthorDto 
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if(entity == null) { /* do smth */}
            var news = 
                    from n in NewsItemDataProvider.NewsItems
                    join a in NewsItemAuthorsDataProvider.NewsItemAuthors
                    on n.Id equals a.NewsItemId
                    where a.AuthorId == entity.Id
                    select n;
                    
            return news.Select(n => new NewsItemDto {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription
            });
            
        }
    }
}