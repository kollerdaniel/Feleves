// <copyright file="MyIoC.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// My inversion of control.
    /// </summary>
    public class MyIoC : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets the instance of my ioc.
        /// </summary>
        public static MyIoC Instance { get; private set; } = new MyIoC();
    }
}
