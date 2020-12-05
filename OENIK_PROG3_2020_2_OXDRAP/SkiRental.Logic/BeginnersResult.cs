// <copyright file="BeginnersResult.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System;

    /// <summary>
    /// This is a result class for a noncrud method.
    /// </summary>
    public class BeginnersResult
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Difficulty.
        /// </summary>
        public string Diff { get; set; }

        /// <summary>
        /// Gets or sets the Payment method.
        /// </summary>
        public string Payment { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Name: {this.Name}, difficulty: {this.Diff}, payment method: {this.Payment}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is BeginnersResult)
            {
                BeginnersResult other = obj as BeginnersResult;
                return this.Name == other.Name && this.Diff == other.Diff && this.Payment == other.Payment;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode(StringComparison.Ordinal) + this.Diff.GetHashCode(StringComparison.Ordinal);
        }
    }
}
