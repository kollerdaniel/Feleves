using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkiRental.Data
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string Name => $"{FirstName} {LastName}";

        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        [MaxLength(20)]
        [Required]
        public string Difficulty { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [MaxLength(20)]
        [Required]
        public string Email { get; set; }

        [Required]
        public int Postcode { get; set; }

        [NotMapped]
        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
