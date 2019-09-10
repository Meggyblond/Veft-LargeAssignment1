using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
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
        public CategoryDto CreateCategory(CategoryInputModel category, string slug)
        {
            var nextInt = CategoryDataProvider.Categories.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            var entity = new Category
            {
                Id = nextInt,
                Name = category.Name,
                Slug = slug,
                ModifiedBy = "Admin"
            };
            CategoryDataProvider.Categories.Add(entity);
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug
            };
        }
        public void UpdateCategory(CategoryInputModel category, int id, string slug)
        {
            var entity = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if(entity == null) {/* do smth */}
            entity.Name = category.Name;
            entity.Slug = slug;
            entity.ModifiedBy = "Admin";
            entity.ModifiedDate = DateTime.Now;
        }
        public void DeleteCategory(int id)
        {
            var entity = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if(entity == null) {/* do smth */}
            CategoryDataProvider.Categories.Remove(entity);
        }
    }
}