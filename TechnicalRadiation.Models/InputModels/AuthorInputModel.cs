<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;

>>>>>>> 461cbd356840cd9bc785aead75ff85d88294c6fe
namespace TechnicalRadiation.Models.InputModels
{
    public class AuthorInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProfileImgSource { get; set; }
        [MaxLength(255)]
        public string Bio { get; set; }
    }
}