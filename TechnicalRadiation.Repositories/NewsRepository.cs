using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dtos;
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

        public NewsItemDto GetNewsItemById(int id)
        {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == id);
            if(entity == null) 
            {
                return null; //Dosmth
            }
            return new NewsItemDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ImgSource = entity.ImgSource,
                ShortDescription = entity.ShortDescription
            };
        }
    }
}