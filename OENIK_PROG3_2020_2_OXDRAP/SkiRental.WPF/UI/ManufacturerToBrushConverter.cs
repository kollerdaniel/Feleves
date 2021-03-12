// <copyright file="ManufacturerToBrushConverter.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.UI
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    using SkiRental.WPF.Data;

    /// <summary>
    /// It is a manufacturer converter class.
    /// </summary>
    public class ManufacturerToBrushConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ManufacturerType pos = (ManufacturerType)value;
            switch (pos)
            {
                default:
                case ManufacturerType.Head: return Brushes.LightGreen;
                case ManufacturerType.Atomic: return Brushes.Salmon;
                case ManufacturerType.Rossignol: return Brushes.LightGray;
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
