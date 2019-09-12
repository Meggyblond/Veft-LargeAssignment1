using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Exceptions;
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
        public CategoryDetailDto GetCategoryById(int categoryId)
        {
            var entity = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == categoryId);
            var newsCount = NewsItemCategoriesDataProvider.NewsItemCategories.Where(n => n.CategoryId == categoryId).Count();
            return new CategoryDetailDto 
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug,
                NumberOfNewsItems = newsCount
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
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"Category with id: {id} was not found");
            }
            entity.Name = category.Name;
            entity.Slug = slug;
            entity.ModifiedBy = "Admin";
            entity.ModifiedDate = DateTime.Now;
        }
        public void DeleteCategory(int id)
        {
            var entity = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if(entity == null) 
            {
                throw new ResourceNotFoundException($"Category with id: {id} was not found");
            }
            CategoryDataProvider.Categories.Remove(entity);
        }
        public void LinkNewsItemToCategory(int newsItemId, int categoryId)
        {
            var newsEntity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == newsItemId);
            if(newsEntity == null) 
            {
                throw new ResourceNotFoundException($"News with id: {newsItemId} was not found");
            }
            var categoryEntity = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == categoryId);
            if(categoryEntity == null) 
            {
                throw new ResourceNotFoundException($"Category with id: {categoryId} was not found");
            }
            var item = new NewsItemCategories
            {
                CategoryId = categoryId,
                NewsItemId = newsItemId
            };
            NewsItemCategoriesDataProvider.NewsItemCategories.Add(item);
        }
    }
}