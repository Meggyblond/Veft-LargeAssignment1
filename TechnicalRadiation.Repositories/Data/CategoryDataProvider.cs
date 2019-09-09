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
                Name = "Breaking News",
                Slug = "breaking-news",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 2,
                Name = "Goverment",
                Slug = "goverment",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 3,
                Name = "Politics",
                Slug = "Politics",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 4,
                Name = "Sports",
                Slug = "Sports",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 5,
                Name = "Technology",
                Slug = "technology",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 6,
                Name = "Weather",
                Slug = "weather",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 7,
                Name = "Current Events",
                Slug = "current-events",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category {
                Id = 8,
                Name = "Traffic & Roads",
                Slug = "traffic-and-roads",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
        };
    }
}