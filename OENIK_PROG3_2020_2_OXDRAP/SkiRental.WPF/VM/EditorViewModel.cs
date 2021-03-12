// <copyright file="EditorViewModel.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.VM
{
    using System;
    using GalaSoft.MvvmLight;
    using SkiRental.WPF.Data;

    /// <summary>
    /// This is an editer view model.
    /// </summary>
    public class EditorViewModel : ViewModelBase
    {
        private SkiEquipment skiEquipment;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        public EditorViewModel()
        {
            this.skiEquipment = new SkiEquipment();
            if (this.IsInDesignMode)
            {
                this.skiEquipment.Name = "Unknown Ski";
                this.skiEquipment.Price = 100;
                this.skiEquipment.Size = 150;
            }
        }

        /// <summary>
        /// Gets the manufacurers.
        /// </summary>
        public Array Manufacturers
        {
            get { return Enum.GetValues(typeof(ManufacturerType)); }
        }

        /// <summary>
        /// Gets the difficulties.
        /// </summary>
        public Array Difficulties
        {
            get { return Enum.GetValues(typeof(DifficultyType)); }
        }

        /// <summary>
        /// Gets or sets a ski equipment.
        /// </summary>
        public SkiEquipment SkiEquipment
        {
            get { return this.skiEquipment; }
            set { this.Set(ref this.skiEquipment, value); }
        }
    }
}
