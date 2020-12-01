// <copyright file="Order.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
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
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
            this.SkiEquipments = new HashSet<SkiEquipments>();
        }

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

        /// <summary>
        /// Gets the ski equipments.
        /// This is a navigation property.
        /// </summary>
        [NotMapped]
        public virtual IReadOnlyCollection<SkiEquipments> SkiEquipments { get; }

        /// <summary>
        /// This is the overrided ToString method of Order.
        /// </summary>
        /// <returns>It returns the ID, payment method, rental dates, promotions and the name of the customer.</returns>
        public override string ToString()
        {
            return $"ID: {this.OrderId}, Payment method: {this.Payment}, Rental dates: {this.FirstDate.ToShortDateString()} - {this.LastDate.ToShortDateString()}, Promotions: {this.Promotion}, Name of customer: {this.Customer.Name}";
        }
    }
}
