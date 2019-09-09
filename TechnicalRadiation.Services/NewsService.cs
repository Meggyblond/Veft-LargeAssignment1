using System.Collections.Generic;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class NewsService
    {
        private NewsRepository _newsRepo = new NewsRepository();

        public IEnumerable<NewsItemDto> GetAllNews(int pageSize, int pageNumber)
        {
            return _newsRepo.GetAllNews(pageSize, pageNumber);
        }
        public NewsItemDto GetNewsItemById(int id)
        {
            return _newsRepo.GetNewsItemById(id);
        }
        public NewsItemDto CreateNews(NewsItemInputModel news) 
        {
            return _newsRepo.CreateNews(news);
        }
    }
}