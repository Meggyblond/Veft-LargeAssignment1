<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;

>>>>>>> 461cbd356840cd9bc785aead75ff85d88294c6fe
namespace TechnicalRadiation.Models.InputModels
{
    public class CategoryInputModel
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}