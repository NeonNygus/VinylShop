using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinylShop.Model;

namespace VinylShop.EfCore
{
    [Table("customer")]
    public class Customer
    {
        [Key,Required]
        public int CustId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNum { get; set; }
    }
}
