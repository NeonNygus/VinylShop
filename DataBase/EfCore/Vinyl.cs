using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinylShop.Model;

namespace VinylShop.EfCore
{
    [Table("vinyl")]
    public class Vinyl
    {
        [Key,Required]
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
