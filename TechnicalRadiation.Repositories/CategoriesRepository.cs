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
    }
}