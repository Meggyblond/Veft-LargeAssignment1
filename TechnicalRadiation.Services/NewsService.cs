using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
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

                var authorsObjectList = getAuthorsObjectByNewsId(news[i].Id);
                news[i].Links.AddListReference("authors", authorsObjectList);

                var categoriesObjectList = getCategoriesObjectByNewsId(news[i].Id);
                news[i].Links.AddListReference("categories", categoriesObjectList);
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

            var authorsObjectList = getAuthorsObjectByNewsId(newsItemId);
            news.Links.AddListReference("authors", authorsObjectList);

            var categoriesObjectList = getCategoriesObjectByNewsId(newsItemId);
            news.Links.AddListReference("categories", categoriesObjectList);

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
        public IEnumerable<object> getAuthorsObjectByNewsId(int newsItemId) 
        {
            var authors = _newsRepo.getAuthorsByNewsId(newsItemId).ToList();
            List<object> authorsObjectList = new List<object>();
            for(int j = 0; j < authors.Count(); j++)
            {
                var authorObj = new { href = $"api/authors/{authors[j].Id}" };
                authorsObjectList.Add(authorObj);
            }
            return authorsObjectList;
        }
        public IEnumerable<object> getCategoriesObjectByNewsId(int newsItemId)
        {
            var categories = _newsRepo.getCategoriesByNewsId(newsItemId).ToList();
            List<object> categoriesObjectList = new List<object>();
            for(int k = 0; k < categories.Count(); k++)
            {
                var categoryObj = new { href = $"api/categories/{categories[k].Id}" };
                categoriesObjectList.Add(categoryObj);
            }
            return categoriesObjectList;
        }
    }
}