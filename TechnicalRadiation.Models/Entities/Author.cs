<<<<<<< HEAD
=======
using System;

>>>>>>> 461cbd356840cd9bc785aead75ff85d88294c6fe
namespace TechnicalRadiation.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImgSource { get; set; }
        public string Bio { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}