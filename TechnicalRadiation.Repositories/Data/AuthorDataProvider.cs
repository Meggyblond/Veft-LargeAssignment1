using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;
using System;

namespace TechnicalRadiation.Repositories.Data
{
    public static class AuthorDataProvider
    {
        private static readonly string _modifiedByName = "TechnicalRadiationAdmin";

        public static List<Author> Authors = new List<Author> 
        {
            new Author {
                Id = 1,
                Name = "Heddi Nice",
                ProfileImgSource = "https://s.abcnews.com/images/Politics/joe-biden-munich-security-conference-gty-jc-190219_hpMain_4x3_992.jpg",
                Bio = "Heddi is a kid from Sunny Selfoss. He is a proper lad that likes fantasy football and writing articles.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author {
                Id = 2,
                Name = "Beddi Nice",
                ProfileImgSource = "https://d.newsweek.com/en/full/943899/pewdiepie-gloria-borger-twitter-youtube-lwiay-incel-who-gloria-borger.jpg?w=1600&h=1600&q=88&f=dc0ac48b451088e8ec8efd984190553a",
                Bio = "Beddi is a kid from Sunny Selfoss. He is a proper lad that likes fantasy football and writing articles.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author {
                Id = 3,
                Name = "Reddi Nice",
                ProfileImgSource = "https://upload.wikimedia.org/wikipedia/commons/0/04/Ben_Shapiro_by_Gage_Skidmore_2.jpg",
                Bio = "Reddi is a kid from Sunny Selfoss. He is a proper lad that likes fantasy football and writing articles.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            },
            new Author {
                Id = 4,
                Name = "Seddi Nice",
                ProfileImgSource = "https://i0.wp.com/www.legossip.net/wp-content/uploads/2017/11/igor-bogdanoff-affaire-julie-jardon.jpg?fit=600%2C300&ssl=1&resize=350%2C200",
                Bio = "Seddi is a kid from Sunny Selfoss. He is a proper lad that likes fantasy football and writing articles.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author {
                Id = 5,
                Name = "Geddi Nice",
                ProfileImgSource = "https://i.redd.it/47ho3jfkgck21.png",
                Bio = "Geddi is a kid from Sunny Selfoss. He is a proper lad that likes fantasy football and writing articles.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author {
                Id = 6,
                Name = "Leddi Nice",
                ProfileImgSource = "https://vignette.wikia.nocookie.net/mrbean/images/4/4b/Mr_beans_holiday_ver2.jpg/revision/latest?cb=20181130033425",
                Bio = "Leddi is a kid from Sunny Selfoss. He is a proper lad that likes fantasy football and writing articles.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            }
        };        
    }
}