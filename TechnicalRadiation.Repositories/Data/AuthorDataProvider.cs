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
                Name = "Joe Biden",
                ProfileImgSource = "https://s.abcnews.com/images/Politics/joe-biden-munich-security-conference-gty-jc-190219_hpMain_4x3_992.jpg",
                Bio = "Biden was born in Scranton, Pennsylvania, and lived there for ten years before moving with his family to Delaware. He became a lawyer in 1969 and was elected to the New Castle County Council in 1970. He was first elected to the U.S. Senate in 1972.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author {
                Id = 2,
                Name = "Gloria Borger",
                ProfileImgSource = "https://d.newsweek.com/en/full/943899/pewdiepie-gloria-borger-twitter-youtube-lwiay-incel-who-gloria-borger.jpg?w=1600&h=1600&q=88&f=dc0ac48b451088e8ec8efd984190553a",
                Bio = "Gloria Borger (pronounced 'glore-ee-uh bore-geh'), also known as Poppy Gloria, was one of PewDiePie’s horcruxes/avatars and is/was a news anchor on PewDiePie's show Pew News.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author {
                Id = 3,
                Name = "Ben Shapiro",
                ProfileImgSource = "https://upload.wikimedia.org/wikipedia/commons/0/04/Ben_Shapiro_by_Gage_Skidmore_2.jpg",
                Bio = "Benjamin Aaron Shapiro (/ʃəˈpɪəroʊ/; born January 15, 1984) is an American conservative political commentator, public speaker, author, and lawyer. At age 17, he became the youngest nationally syndicated columnist in the United States.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            },
            new Author {
                Id = 4,
                Name = "Igor and Grichka Bogdanoff",
                ProfileImgSource = "https://i0.wp.com/www.legossip.net/wp-content/uploads/2017/11/igor-bogdanoff-affaire-julie-jardon.jpg?fit=600%2C300&ssl=1&resize=350%2C200",
                Bio = "Rothschilds bow to Bogdanoffs, In contact with aliens, Possess psychic-like abilities, Control France with an iron but fair fist. Both brothers said to have 215+ IQ, such intelligence on Earth has only existed deep in Tibetan monasteries & Area 51. ",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author {
                Id = 5,
                Name = "Pepsi Man",
                ProfileImgSource = "https://i.redd.it/47ho3jfkgck21.png",
                Bio = "It is not known where or when pepsiman was born, though it is known that his father was an addict, and he was born on a Tuesday. Pepsiman himself, however, has a much more detailed history.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author {
                Id = 6,
                Name = "Mr Bean",
                ProfileImgSource = "https://vignette.wikia.nocookie.net/mrbean/images/4/4b/Mr_beans_holiday_ver2.jpg/revision/latest?cb=20181130033425",
                Bio = "Mr Bean turns the most ordinary situations into moments of excruciating embarrassment.",
                ModifiedBy = _modifiedByName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            }
        };        
    }
}