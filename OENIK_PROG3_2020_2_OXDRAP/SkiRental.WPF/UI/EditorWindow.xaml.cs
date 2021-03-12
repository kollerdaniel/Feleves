// <copyright file="EditorWindow.xaml.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.UI
{
    using System.Windows;
    using SkiRental.WPF.Data;
    using SkiRental.WPF.VM;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        private readonly EditorViewModel vM;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        public EditorWindow()
        {
            this.InitializeComponent();

            this.vM = this.FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        /// <param name="oldSkiEquipment">Old ski equipment.</param>
        public EditorWindow(SkiEquipment oldSkiEquipment)
            : this()
        {
            this.vM.SkiEquipment = oldSkiEquipment;
        }

        /// <summary>
        /// Gets a ski equipment.
        /// </summary>
        public SkiEquipment SkiEquipment { get => this.vM.SkiEquipment; }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
