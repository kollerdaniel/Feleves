// <copyright file="PromotionResult.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    /// <summary>
    /// This is a result class for a noncrud method.
    /// </summary>
    public class PromotionResult
    {
        /// <summary>
        /// Gets or sets the Size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the Promotion.
        /// </summary>
        public int? Promotion { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Size: {this.Size}, promotion: {this.Promotion}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is PromotionResult)
            {
                PromotionResult other = obj as PromotionResult;
                return this.Size == other.Size && this.Promotion == other.Promotion;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (int)this.Promotion + this.Size;
        }
    }
}
