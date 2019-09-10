using System.Collections.Generic;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class CategoriesService
    {
        private CategoriesRepository _categoriesRepo = new CategoriesRepository();

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return _categoriesRepo.GetAllCategories();
        }
        public CategoryDto GetCategoryById(int id)
        {
            return _categoriesRepo.GetCategoryById(id);
        }
        public CategoryDto CreateCategory(CategoryInputModel category)
        {
            string slug = category.Name.Replace(" ", "-").ToLower();
            return _categoriesRepo.CreateCategory(category, slug);
        }
    }
}