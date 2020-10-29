using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkiRental.Data
{
    [Table("SkiEquipments")]
    public class SkiEquipments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkiEquipmentsId { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MaxLength(20)]
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Size { get; set; }

        [MaxLength(20)]
        [Required]
        public string Difficulty { get; set; }

        [Required]
        public bool Status { get; set; } // <= available or not

        public virtual Basket Basket { get; set; }
        [ForeignKey(nameof(Basket))]
        public int BasketId { get; set; }
    }
}
