// <copyright file="Customer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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

        [NotMapped]
        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public override string ToString()
        {
            return ($"{this.Name}, {this.Password}, {this.Difficulty}");
        }
    }
}
