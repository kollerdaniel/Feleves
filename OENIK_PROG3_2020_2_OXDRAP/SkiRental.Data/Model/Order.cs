using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkiRental.Data
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public virtual Basket Basket { get; set; }
        [ForeignKey(nameof(Basket))]
        public int BasketId { get; set; }

        [Required]
        public DateTime FirstDate { get; set; }
        
        [Required]
        public DateTime LastDate { get; set; }

        [MaxLength(20)]
        [Required]
        public string Payment { get; set; }

        [Required]
        public bool CustomerPaid { get; set; }

        [Required]
        public int? Promotion { get; set; }
    }
}
