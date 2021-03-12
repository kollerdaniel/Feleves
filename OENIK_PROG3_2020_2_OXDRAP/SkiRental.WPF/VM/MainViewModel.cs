// <copyright file="MainViewModel.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.VM
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SkiRental.WPF.BL;
    using SkiRental.WPF.Data;

    /// <summary>
    /// This is the main view model class.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ISkiEquipmentLogic logic;
        private SkiEquipment equipmentSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="skiEquipmentLogic">Logic of ski equipments.</param>
        public MainViewModel(ISkiEquipmentLogic skiEquipmentLogic)
        {
            this.logic = skiEquipmentLogic;

            this.Equipments = new ObservableCollection<SkiEquipment>();

            if (this.IsInDesignMode)
            {
                SkiEquipment s1 = new SkiEquipment() { Name = "Supershape", Price = 300, Difficulty = DifficultyType.Advanced, Manufacturer = ManufacturerType.Rossignol };
                SkiEquipment s2 = new SkiEquipment() { Name = "Redster", Price = 400, Size = 170, Manufacturer = ManufacturerType.Atomic };

                this.Equipments.Add(s1);
                this.Equipments.Add(s2);
            }

            this.AddCmd = new RelayCommand(() => this.logic.AddSkiEquipment(this.Equipments));
            this.ModCmd = new RelayCommand(() => this.logic.ModSkiEquipment(this.EquipmentSelected));
            this.DelCmd = new RelayCommand(() => this.logic.DeleteSkiEquipment(this.Equipments, this.EquipmentSelected));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<ISkiEquipmentLogic>())
        {
        }

        /// <summary>
        /// Gets the collection of ski equipments.
        /// </summary>
        public ObservableCollection<SkiEquipment> Equipments { get; private set; }

        /// <summary>
        /// Gets or sets the selected equipment.
        /// </summary>
        public SkiEquipment EquipmentSelected
        {
            get { return this.equipmentSelected; }
            set { this.Set(ref this.equipmentSelected, value); }
        }

        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets the Mod command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets the Del command.
        /// </summary>
        public ICommand DelCmd { get; private set; }
    }
}
