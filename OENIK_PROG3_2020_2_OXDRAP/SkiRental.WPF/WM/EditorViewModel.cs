// <copyright file="EditorViewModel.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.WM
{
    using GalaSoft.MvvmLight;
    using SkiRental.WPF.Data;

    /// <summary>
    /// This is an editer view model.
    /// </summary>
    public class EditorViewModel : ViewModelBase
    {
        private SkiEquipment skiEquipment;

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
