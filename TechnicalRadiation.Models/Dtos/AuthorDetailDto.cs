namespace TechnicalRadiation.Models.Dtos
{
    public class AuthorDetailDto : HyperMediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfielImgSource { get; set; }
        public string Bio { get; set; }
    }
}