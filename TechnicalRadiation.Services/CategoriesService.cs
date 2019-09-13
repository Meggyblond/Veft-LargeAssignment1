using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class CategoriesService
    {
        private CategoriesRepository _categoriesRepo = new CategoriesRepository();

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var cats = _categoriesRepo.GetAllCategories().ToList();
            for(int i = 0; i < cats.Count(); i++)
            {
                var obj = new { href = $"api/categories/{cats[i].Id}" };
                cats[i].Links.AddReference("self", obj);
                cats[i].Links.AddReference("edit", obj);
                cats[i].Links.AddReference("delete", obj);
            }
            return cats;
        }
        public CategoryDetailDto GetCategoryById(int categoryId)
        {
            var obj = new { href = $"api/categories/{categoryId}" };
            var cat = _categoriesRepo.GetCategoryById(categoryId);
            cat.Links.AddReference("self", obj);
            cat.Links.AddReference("edit", obj);
            cat.Links.AddReference("delete", obj);
            return cat;
        }
        public CategoryDto CreateCategory(CategoryInputModel category)
        {
            string slug = category.Name.Replace(" ", "-").ToLower();
            return _categoriesRepo.CreateCategory(category, slug);
        }
        public void UpdateCategory(CategoryInputModel category, int id)
        {
            string slug = category.Name.Replace(" ", "-").ToLower();
            _categoriesRepo.UpdateCategory(category, id, slug);
        }
        public void DeleteCategory(int id)
        {
            _categoriesRepo.DeleteCategory(id);
        }
        public void LinkNewsItemToCategory(int newsItemId, int categoryId)
        {
            _categoriesRepo.LinkNewsItemToCategory(newsItemId, categoryId);
        }
    }
}