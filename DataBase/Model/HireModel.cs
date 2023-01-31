using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinylShop.EfCore;

namespace VinylShop.Model
{
    public class HireModel
    {
        [Key, Required]
        public int HireId { get; set; }
        public int VinylId { get; set; }
        public virtual Vinyl Vinyl { get; set; }
        public int CustId { get; set; }
        public virtual Customer Customer { get; set; }
        public System.DateTime HireDate { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
