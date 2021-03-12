// <copyright file="ISkiEquipmentLogic.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.BL
{
    using System.Collections.Generic;
    using SkiRental.WPF.Data;

    /// <summary>
    /// It is an interface of ski equipment logic.
    /// </summary>
    public interface ISkiEquipmentLogic
    {
        /// <summary>
        /// This method create an object.
        /// </summary>
        /// <param name="list">A list of ski equipments.</param>
        void AddSkiEquipment(IList<SkiEquipment> list);

        /// <summary>
        /// This method modifis an object.
        /// </summary>
        /// <param name="skiEquipmentModify">A ski equipment object.</param>
        void ModSkiEquipment(SkiEquipment skiEquipmentModify);

        /// <summary>
        /// This method deletes an object.
        /// </summary>
        /// <param name="list">A list oof ski equipments.</param>
        /// <param name="skiEquipment">A ski equipment object.</param>
        void DeleteSkiEquipment(IList<SkiEquipment> list, SkiEquipment skiEquipment);

        /// <summary>
        /// This is the get all method.
        /// </summary>
        /// <returns>It returns a list of ski equipments.</returns>
        IList<SkiEquipment> GetAllSkiEquipment();
    }
}
