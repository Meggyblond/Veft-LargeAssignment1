using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class NewsRepository
    {
        public IEnumerable<NewsItemDto> GetAllNews(int pageSize)
        {
            return NewsItemDataProvider.NewsItems.Select(n => new NewsItemDto
            {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription
            }).Take(pageSize);
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