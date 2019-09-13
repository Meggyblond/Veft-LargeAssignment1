using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Exceptions;
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
        public AuthorDetailDto GetAuthorById(int authorId)
        {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == authorId);
            if(entity == null)
            {
                throw new ResourceNotFoundException($"Author with id: {authorId} was not found");
            }
            return new AuthorDetailDto 
            {
                Id = entity.Id,
                Name = entity.Name,
                ProfielImgSource = entity.ProfileImgSource,
                Bio = entity.Bio
            };
        }
        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);
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
            int nextInt = 0;
            if(AuthorDataProvider.Authors.Count == 0)
            {
                nextInt = 1;
            }
            else 
            {
                nextInt = AuthorDataProvider.Authors.OrderByDescending(a => a.Id).FirstOrDefault().Id + 1;
            }
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
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"Author with id: {id} was not found");
            }
            entity.Name = author.Name;
            entity.ProfileImgSource = author.ProfileImgSource;
            entity.Bio = author.Bio;
            entity.ModifiedBy = "Admin";
            entity.ModifiedDate = DateTime.Now;
        }
        public void DeleteAuthor(int id)
        {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"Author with id: {id} was not found");
            }
            AuthorDataProvider.Authors.Remove(entity);
        }
        public void LinkAuthorToNewsItem(int authorId, int newsId)
        {
            var authorEntity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == authorId);
            if(authorEntity == null) 
            {
                throw new ResourceNotFoundException($"Author with id: {authorId} was not found");
            }
            var newsEntity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == newsId);
            if(newsEntity == null) 
            {
                throw new ResourceNotFoundException($"News with id: {newsId} was not found");
            }
            var item = new NewsItemAuthors
            {
                AuthorId = authorId,
                NewsItemId = newsId
            };
            NewsItemAuthorsDataProvider.NewsItemAuthors.Add(item);
        }
    }
}