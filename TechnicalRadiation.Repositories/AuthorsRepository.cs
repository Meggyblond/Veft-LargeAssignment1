using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class AuthorsRepository
    {
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
        public AuthorDto CreateAuthor(AuthorInputModel author)
        {
            var nextInt = AuthorDataProvider.Authors.OrderByDescending(a => a.Id).FirstOrDefault().Id + 1;
            var entity = new Author
            {
                Id = nextInt,
                Name = author.Name,
                ProfileImgSource = author.ProfileImgSource,
                Bio = author.Bio,
                ModifiedBy = "Admin",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            AuthorDataProvider.Authors.Add(entity);
            return new AuthorDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        public void UpdateAuthor(AuthorInputModel author, int id)
        {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if(entity == null) {/* do smth */}
            entity.Name = author.Name;
            entity.ProfileImgSource = author.ProfileImgSource;
            entity.Bio = author.Bio;
            entity.ModifiedBy = "Admin";
            entity.ModifiedDate = DateTime.Now;
        }
        public void DeleteAuthor(int id)
        {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if(entity == null) {/* do smth */}
            AuthorDataProvider.Authors.Remove(entity);
        }
    }
}