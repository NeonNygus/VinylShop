using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinylShop.Model;

namespace VinylShop.EfCore
{
    [Table("hire")]
    public class Hire
    {
        [Key,Required]
        public int HireId { get; set; }
        public int VinylId { get; set; }
        [ForeignKey("VinylId")]
        public virtual Vinyl Vinyl { get; set; }
        public int CustId { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }
        public System.DateTime HireDate { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
