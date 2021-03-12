// <copyright file="IEditorService.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.BL
{
    using SkiRental.WPF.Data;

    /// <summary>
    /// This is an important interface for business logic.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// Whit this, I can edit a ski equipment.
        /// </summary>
        /// <param name="s">A ski equipment object.</param>
        /// <returns>Okay or cancel.</returns>
        bool EditSkiEquipment(SkiEquipment s);
    }
}
