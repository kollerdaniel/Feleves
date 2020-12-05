// <copyright file="SkiEquipments.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
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
        /// Gets or sets a virtual property for the Order objects.
        /// </summary>
        [NotMapped]
        public virtual Order Order { get; set; }

        /// <summary>
        /// Gets or sets the basket id of the equipments, and it is a foreign key.
        /// </summary>
        [ForeignKey(nameof(Order))]

        public virtual int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the name of the equipments.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer of the equipments.
        /// </summary>
        [MaxLength(100)]
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
        [MaxLength(100)]
        [Required]
        public string Difficulty { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is available or isn't.
        /// </summary>
        [Required]
        public bool Status { get; set; }

        /// <summary>
        /// This is the overrided ToString method of Ski equipments.
        /// </summary>
        /// <returns>It returns the name, the manufacturer, the price, the size, the difficulty and the status of the ski.</returns>
        public override string ToString()
        {
            return $"ID: {this.SkiEquipmentsId}, name: {this.Name}, manufacturer: {this.Manufacturer}, price: {this.Price}, size: {this.Size}, difficulty: {this.Difficulty}, status: {this.Status}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is SkiEquipments)
            {
                SkiEquipments other = obj as SkiEquipments;
                return this.Difficulty == other.Difficulty && this.Manufacturer == other.Manufacturer && this.Price == other.Price && this.Size == other.Size && this.SkiEquipmentsId == other.SkiEquipmentsId && this.Status == other.Status;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.SkiEquipmentsId;
        }
    }
}
