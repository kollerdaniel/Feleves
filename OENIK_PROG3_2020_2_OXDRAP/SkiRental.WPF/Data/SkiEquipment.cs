// <copyright file="SkiEquipment.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.Data
{
    using System.Linq;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// This is the class of the ski equipments.
    /// </summary>
    public class SkiEquipment : ObservableObject
    {
        private string name;

        private string manufacturer;

        private int price;

        private int size;

        private string difficulty;

        /// <summary>
        /// Gets or sets the id of the equipments, and this is the primary key.
        /// </summary>
        public int SkiEquipmentsId { get; set; }

        /// <summary>
        /// Gets or sets the basket id of the equipments, and it is a foreign key.
        /// </summary>
        public virtual int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the name of the equipments.
        /// </summary>
        public string Name
        {
            get { return this.name; } set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets the manufacturer of the equipments.
        /// </summary>
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.Set(ref this.manufacturer, value); }
        }

        /// <summary>
        /// Gets or sets the price of the equipments.
        /// </summary>
        public int Price
        {
            get { return this.price; }
            set { this.Set(ref this.price, value); }
        }

        /// <summary>
        /// Gets or sets the size of the equipments.
        /// </summary>
        public int Size
        {
            get { return this.size; }
            set { this.Set(ref this.size, value); }
        }

        /// <summary>
        /// Gets or sets the difficulty of the equipments.
        /// </summary>
        public string Difficulty
        {
            get { return this.difficulty; }
            set { this.Set(ref this.difficulty, value); }
        }

        /// <summary>
        /// It makes a copy of the implemented objects.
        /// </summary>
        /// <param name="other">A ski equipment object.</param>
        public void CopyFrom(SkiEquipment other)
        {
            this.GetType().GetProperties().ToList().ForEach(
                prop => prop.SetValue(this, prop.GetValue(other)));
        }
    }
}
