using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels
{
    public class AuthorInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)")]
        public string ProfileImgSource { get; set; }
        [MaxLength(255)]
        public string Bio { get; set; }
    }
}