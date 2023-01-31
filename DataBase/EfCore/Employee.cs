using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VinylShop.Model;

namespace VinylShop.EfCore
{
    [Table("employee")]
    public class Employee
    {
        [Key,Required]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNum { get; set; }
    }
}
