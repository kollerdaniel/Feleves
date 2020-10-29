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
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        public DateTime FirstDate { get; set; }
        
        [Required]
        public DateTime LastDate { get; set; }

        [MaxLength(20)]
        [Required]
        public string Payment { get; set; }

        [MaxLength(20)]
        [Required]
        public int Quantity { get; set; }

        [MaxLength(20)]
        [Required]
        public bool Promotion { get; set; }
    }
}
