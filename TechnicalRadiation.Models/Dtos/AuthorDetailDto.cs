namespace TechnicalRadiation.Models.Dtos
{
    public class AuthorDetailDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ProfielImgSource { get; set; }
        public string Bio { get; set; }
    }
}