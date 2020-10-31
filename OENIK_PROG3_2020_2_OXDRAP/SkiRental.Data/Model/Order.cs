// <copyright file="Order.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This is the table of the orders.
    /// </summary>
    [Table("Orders")]
    public class Order
    {
        /// <summary>
        /// Gets or sets the id of the orders, and this is the primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        [NotMapped]
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the id of the customer, and this is a foreign key.
        /// </summary>
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the basket.
        /// </summary>
        //[NotMapped]
        //public virtual Basket Basket { get; set; }

        ///// <summary>
        ///// Gets or sets the id of the basket, and this is a foreign key.
        ///// </summary>
        //[ForeignKey(nameof(Basket))]
        //public int BasketId { get; set; }

        /// <summary>
        /// Gets or sets the first date of the orders.
        /// </summary>
        [Required]
        public DateTime FirstDate { get; set; }

        /// <summary>
        /// Gets or sets the last date of the orders.
        /// </summary>
        [Required]
        public DateTime LastDate { get; set; }

        /// <summary>
        /// Gets or sets the payment mode of the orders.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Payment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the payment status of the orders.
        /// </summary>
        [Required]
        public bool CustomerPaid { get; set; }

        /// <summary>
        /// Gets or sets the quantity of promotion of the orders.
        /// </summary>
        public int? Promotion { get; set; }

        public override string ToString()
        {
            return ($"{this.Payment}");
        }
        public virtual ICollection<SkiEquipments> SkiEquipments { get; set; }
        public Order()
        {
            this.SkiEquipments = new HashSet<SkiEquipments>();
        }
    }
}
