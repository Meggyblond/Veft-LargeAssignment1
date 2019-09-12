using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class NewsRepository
    {
        public IEnumerable<NewsItemDto> GetAllNews(int pageSize, int pageNumber)
        {
            var newsItems = NewsItemDataProvider.NewsItems.OrderByDescending(n => n.PublishDate).Select(n => new NewsItemDto
            {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription
            });
            var envelope = new Envelope<NewsItemDto>(pageNumber, pageSize, newsItems);

            return envelope.Items;
        }
        public NewsItemDetailDto GetNewsItemById(int newsItemId)
        {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == newsItemId);
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"News with id: {newsItemId} was not found");
            }
            return new NewsItemDetailDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ImgSource = entity.ImgSource,
                ShortDescription = entity.ShortDescription,
                LongDescription = entity.LongDescription,
                PublishDate = entity.PublishDate
            };
        }
        public NewsItemDto CreateNews(NewsItemInputModel news)
        {
            var nextInt = NewsItemDataProvider.NewsItems.OrderByDescending(n => n.Id).FirstOrDefault().Id + 1;
            var entity = new NewsItem
            {
                Id = nextInt,
                Title = news.Title,
                ImgSource = news.ImgSource,
                ShortDescription = news.ShortDescription,
                LongDescription = news.LongDescription,
                PublishDate = news.PublishDate,
                ModifiedBy = "Admin",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            NewsItemDataProvider.NewsItems.Add(entity);
            return new NewsItemDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ImgSource = entity.ImgSource,
                ShortDescription = entity.ShortDescription
            };
        }
        public void UpdateNews(NewsItemInputModel news, int id)
        {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == id);
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"News with id: {id} was not found");
            }
            entity.Title = news.Title;
            entity.ImgSource = news.ImgSource;
            entity.ShortDescription = news.ShortDescription;
            entity.LongDescription = news.LongDescription;
            entity.PublishDate = news.PublishDate;
            entity.ModifiedBy = "Admin";
            entity.ModifiedDate = DateTime.Now;
        }
        public void DeleteNews(int id)
        {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == id);
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"News with id: {id} was not found");
            }
            NewsItemDataProvider.NewsItems.Remove(entity);
        }
        public IEnumerable<Author> getAuthorsByNewsId(int newsId)
        {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == newsId);
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"News with id: {newsId} was not found");
            }
            var authors = 
                    from a in AuthorDataProvider.Authors
                    join n in NewsItemAuthorsDataProvider.NewsItemAuthors
                    on a.Id equals n.AuthorId
                    where n.NewsItemId == entity.Id
                    select a;

            return authors;
        }
        public IEnumerable<Category> getCategoriesByNewsId(int newsId)
        {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == newsId);
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"News with id: {newsId} was not found");
            }
            var categories = 
                from c in CategoryDataProvider.Categories
                join n in NewsItemCategoriesDataProvider.NewsItemCategories
                on c.Id equals n.CategoryId
                where n.NewsItemId == entity.Id
                select c;
            
            return categories;
        }
    }
}