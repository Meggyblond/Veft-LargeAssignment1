using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class CategoriesRepository
    {
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return CategoryDataProvider.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug
            });
        }
        public CategoryDto GetCategoryById(int id)
        {
            var entity = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if(entity == null) { /* do smth*/ }
            return new CategoryDto 
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug
            };
        }
    }
}