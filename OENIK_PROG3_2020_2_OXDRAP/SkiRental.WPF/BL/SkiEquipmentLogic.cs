// <copyright file="SkiEquipmentLogic.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.BL
{
    using System;
    using System.Collections.Generic;
    using GalaSoft.MvvmLight.Messaging;
    using SkiRental.WPF.Data;

    /// <summary>
    /// This is the ski equipment logic class.
    /// </summary>
    public class SkiEquipmentLogic : ISkiEquipmentLogic
    {
        private IEditorService editorService;
        private IMessenger messengerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkiEquipmentLogic"/> class.
        /// </summary>
        /// <param name="editorService">An editer service.</param>
        /// <param name="messengerService">A messenger service.</param>
        public SkiEquipmentLogic(IEditorService editorService, IMessenger messengerService)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
        }

        /// <inheritdoc/>
        public void AddSkiEquipment(IList<SkiEquipment> list)
        {
            SkiEquipment newSkiEquipment = new SkiEquipment();
            if (this.editorService.EditSkiEquipment(newSkiEquipment) == true)
            {
                list?.Add(newSkiEquipment);
                this.messengerService.Send("ADD OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("ADD CANCEL", "LogicResult");
            }
        }

        /// <inheritdoc/>
        public void DeleteSkiEquipment(IList<SkiEquipment> list, SkiEquipment skiEquipment)
        {
            if (skiEquipment != null && list != null && list.Remove(skiEquipment))
            {
                this.messengerService.Send("DELETE OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("DELETE FAILED", "LogicResult");
            }
        }

        /// <inheritdoc/>
        public IList<SkiEquipment> GetAllSkiEquipment()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void ModSkiEquipment(SkiEquipment skiEquipmentToModify)
        {
            if (skiEquipmentToModify == null)
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            SkiEquipment clone = new SkiEquipment();
            clone.CopyFrom(skiEquipmentToModify);
            if (this.editorService.EditSkiEquipment(clone) == true)
            {
                skiEquipmentToModify.CopyFrom(clone);
                this.messengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("MODIFY CANCEL", "LogicResult");
            }
        }
    }
}
