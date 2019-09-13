using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Entities;
using System.Collections.Generic;
using System;

namespace TechnicalRadiation.Repositories.Data
{
    public static class CategoryDataProvider
    {
        private static readonly string _modifiedByName = "TechnicalRadiationAdmin";

        public static List<Category> Categories = new List<Category> {
            
            new Category {
                Id = 1,
                Name = "Nice News",
                Slug = "nice-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 2,
                Name = "Bad News",
                Slug = "bad-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 3,
                Name = "Real News",
                Slug = "real-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 4,
                Name = "Fake News",
                Slug = "fake-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 5,
                Name = "Other News",
                Slug = "other-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 6,
                Name = "Thug News",
                Slug = "thug-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 7,
                Name = "Soccer News",
                Slug = "soccer-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 8,
                Name = "Spider News",
                Slug = "spider-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
        };
    }
}