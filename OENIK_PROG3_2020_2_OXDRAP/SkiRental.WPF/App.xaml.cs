// <copyright file="App.xaml.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF
{
    using System.Windows;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Messaging;
    using SkiRental.WPF.BL;
    using SkiRental.WPF.UI;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoC.Instance);

            MyIoC.Instance.Register<IEditorService, EditorServiceViaWindow>();

            MyIoC.Instance.Register<IMessenger>(() => Messenger.Default);

            MyIoC.Instance.Register<ISkiEquipmentLogic, SkiEquipmentLogic>();
        }
    }
}
