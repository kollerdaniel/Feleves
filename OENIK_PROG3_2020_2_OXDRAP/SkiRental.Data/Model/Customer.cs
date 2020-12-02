// <copyright file="Customer.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This is the table of the customers.
    /// </summary>
    [Table("Customers")]
    public class Customer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        /// <summary>
        /// Gets or sets the id of the customers, and this is the primary key of the table.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customers.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the customers.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name of the customers.
        /// </summary>
        [NotMapped]
        public string Name => $"{this.FirstName} {this.LastName}";

        /// <summary>
        /// Gets or sets the password of the customers.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the difficulty of the customers.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the size of the customers.
        /// </summary>
        [Required]
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the birthdate of the customers.
        /// </summary>
        [Required]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Gets or sets the email of the customers.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the postcode of the customers.
        /// </summary>
        [Required]
        public int Postcode { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// This is a navigation property.
        /// </summary>
        [NotMapped]
        public virtual IReadOnlyCollection<Order> Orders { get; set; }

        /// <summary>
        /// This is the overrided ToString method of Customer.
        /// </summary>
        /// <returns>It returns the name, password, difficulty, size, birthdate, postcode and email of the customer.</returns>
        public override string ToString()
        {
            return $"Customers name: {this.Name}, password: {this.Password}, difficulty: {this.Difficulty}, size: {this.Size}, birthdate: {this.Birthdate.ToShortDateString()}, postcode: {this.Postcode}, email: {this.Email}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                Customer other = obj as Customer;
                return this.Birthdate == other.Birthdate && this.CustomerId == other.CustomerId && this.Difficulty == other.Difficulty && this.Email == other.Email && this.FirstName == other.FirstName && this.LastName == other.LastName && this.Orders == other.Orders && this.Password == other.Password && this.Postcode == other.Postcode && this.Size == other.Size;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.CustomerId;
        }
    }
}
