using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkiRental.Data
{
    [Table("Basket")]
    public class Basket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BasketId { get; set; }

        public virtual Order Order { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        public virtual SkiEquipments SkiEquipments { get; set; }
        [ForeignKey(nameof(SkiEquipments))]
        public int SkiEquipmentsId { get; set; }


        [NotMapped]
        public virtual ICollection<SkiEquipments> SkiEquipment { get; set; }

        public Basket()
        {
            SkiEquipment = new HashSet<SkiEquipments>();
        }
    }
}
