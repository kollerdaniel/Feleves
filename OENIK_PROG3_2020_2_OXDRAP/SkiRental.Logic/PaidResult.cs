// <copyright file="PaidResult.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System;

    /// <summary>
    /// This is a result class for a noncrud method.
    /// </summary>
    public class PaidResult
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the Size.
        /// </summary>
        public int Size { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Name: {this.Name}, manufacturer: {this.Manufacturer}, price: {this.Size}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is PaidResult)
            {
                PaidResult other = obj as PaidResult;
                return this.Name == other.Name && this.Manufacturer == other.Manufacturer && this.Size == other.Size;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode(StringComparison.Ordinal) + this.Size;
        }
    }
}
