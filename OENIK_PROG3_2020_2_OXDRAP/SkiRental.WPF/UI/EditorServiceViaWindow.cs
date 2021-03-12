// <copyright file="EditorServiceViaWindow.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.UI
{
    using SkiRental.WPF.BL;
    using SkiRental.WPF.Data;

    /// <summary>
    /// This is the editor service via window class.
    /// </summary>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <inheritdoc/>
        public bool EditSkiEquipment(SkiEquipment s)
        {
            EditorWindow win = new EditorWindow(s);
            return win.ShowDialog() ?? false;
        }
    }
}
