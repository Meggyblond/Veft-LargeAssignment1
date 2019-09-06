using System.Collections.Generic;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class NewsService
    {
        private NewsRepository _newsRepo = new NewsRepository();

        public IEnumerable<NewsItemDto> GetAllNews(int pageSize)
        {
            return _newsRepo.GetAllNews(pageSize);
        }
        public NewsItemDto GetNewsItemById(int id)
        {
            return _newsRepo.GetNewsItemById(id);
        }
    }
}