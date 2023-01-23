namespace VinylShop.Model
{
    public class VinylModel
    {
        public int VinylId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public FormatEnum Format { get; set; }
        public int ReleaseYear { get; set; }
        public GenreEnum Genre { get; set; }
        public string Label { get; set; }
        public string CatalogueNum { get; set; }
    }
}
