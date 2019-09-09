<<<<<<< HEAD
=======
using System;
using System.ComponentModel.DataAnnotations;

>>>>>>> 461cbd356840cd9bc785aead75ff85d88294c6fe
namespace TechnicalRadiation.Models.InputModels
{
    public class NewsItemInputModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImgSource { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShortDescription { get; set; }
        [MinLength(50)]
        [MaxLength(255)]
        public string LongDescription { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
    }
}