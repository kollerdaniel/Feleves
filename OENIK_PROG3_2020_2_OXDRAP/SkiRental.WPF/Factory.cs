// <copyright file="Factory.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF
{
    using SkiRental.Data;

    /// <summary>
    /// This is the factory class.
    /// </summary>
    public class Factory
    {
        private SkiRentalContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.Ctx = new SkiRentalContext();
        }

        /// <summary>
        /// Gets or sets the datbase.
        /// </summary>
        public SkiRentalContext Ctx { get => this.ctx; set => this.ctx = value; }
    }
}
