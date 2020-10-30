// <copyright file="SkiEquipments.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This is the table of the ski equipments.
    /// </summary>
    [Table("SkiEquipments")]
    public class SkiEquipments
    {
        /// <summary>
        /// Gets or sets the id of the equipments, and this is the primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkiEquipmentsId { get; set; }

        /// <summary>
        /// Gets or sets the basket id of the equipments, and it is a foreign key.
        /// </summary>
        [ForeignKey(nameof(Basket))]
        public int BasketId { get; set; }

        /// <summary>
        /// Gets or sets the name of the equipments.
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer of the equipments.
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the price of the equipments.
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the size of the equipments.
        /// </summary>
        [Required]
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the difficulty of the equipments.
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string Difficulty { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is available or isn't.
        /// </summary>
        [Required]
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets the basket of the equipments.
        /// </summary>
        public virtual Basket Basket { get; set; }
    }
}
