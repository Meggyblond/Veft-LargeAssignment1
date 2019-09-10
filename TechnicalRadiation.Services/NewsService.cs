using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class NewsService
    {
        private NewsRepository _newsRepo = new NewsRepository();

        public IEnumerable<NewsItemDto> GetAllNews(int pageSize, int pageNumber)
        {

            var news = _newsRepo.GetAllNews(pageSize, pageNumber).ToList();
            for(int i = 0; i < news.Count(); i++)
            {
                var obj = new { href = $"api/{news[i].Id}"};
                news[i].Links.AddReference("self", obj);
                news[i].Links.AddReference("edit", obj);
                news[i].Links.AddReference("delete", obj);
            }
            return news;
        }
        public NewsItemDetailDto GetNewsItemById(int newsItemId)
        {
            var obj = new { href = $"api/{newsItemId}" };
            var news = _newsRepo.GetNewsItemById(newsItemId);
            news.Links.AddReference("self", obj);
            news.Links.AddReference("edit", obj);
            news.Links.AddReference("delete", obj);
            return news;
        }
        public NewsItemDto CreateNews(NewsItemInputModel news) 
        {
            return _newsRepo.CreateNews(news);
        }
        public void UpdateNews(NewsItemInputModel news, int id)
        {
            _newsRepo.UpdateNews(news, id);
        }
        public void DeleteNews(int id)
        {
            _newsRepo.DeleteNews(id);
        }
    }
}