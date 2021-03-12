// <copyright file="SkiEquipmentLogic.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.WPF.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GalaSoft.MvvmLight.Messaging;
    using SkiRental.WPF.Data;

    /// <summary>
    /// This is the ski equipment logic class.
    /// </summary>
    public class SkiEquipmentLogic : ISkiEquipmentLogic
    {
        private IEditorService editorService;
        private IMessenger messengerService;
        private Factory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkiEquipmentLogic"/> class.
        /// </summary>
        /// <param name="editorService">An editer service.</param>
        /// <param name="messengerService">A messenger service.</param>
        /// <param name="factory">A factory.</param>
        public SkiEquipmentLogic(IEditorService editorService, IMessenger messengerService, Factory factory)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
            this.factory = factory;
        }

        /// <inheritdoc/>
        public void AddSkiEquipment(IList<SkiEquipment> list)
        {
            SkiEquipment newSkiEquipment = new SkiEquipment();
            if (this.editorService.EditSkiEquipment(newSkiEquipment) == true)
            {
                list?.Add(newSkiEquipment);
                this.factory.Ctx.SkiEquipments.Add(new SkiRental.Data.SkiEquipments() { OrderId = 1, Name = newSkiEquipment.Name, Manufacturer = newSkiEquipment.Manufacturer.ToString(), Size = newSkiEquipment.Size, Price = newSkiEquipment.Price, Difficulty = newSkiEquipment.Difficulty.ToString() });
                this.factory.Ctx.SaveChanges();
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
                var item = this.factory.Ctx.SkiEquipments.Where(x => x.Name == skiEquipment.Name && x.Manufacturer == skiEquipment.Manufacturer.ToString() && x.Price == skiEquipment.Price && x.Size == skiEquipment.Size && x.Price == skiEquipment.Price).SingleOrDefault();
                this.factory.Ctx.SkiEquipments.Remove(item);
                this.factory.Ctx.SaveChanges();
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
            IList<SkiEquipment> outp = new List<SkiEquipment>();
            foreach (var item in this.factory.Ctx.SkiEquipments.ToList())
            {
                SkiEquipment newSkiEquipment = new SkiEquipment();
                if (item.Difficulty == "beginner")
                {
                    newSkiEquipment.Difficulty = DifficultyType.Beginner;
                }

                if (item.Difficulty == "advanced")
                {
                    newSkiEquipment.Difficulty = DifficultyType.Advanced;
                }

                if (item.Difficulty == "pro")
                {
                    newSkiEquipment.Difficulty = DifficultyType.Pro;
                }

                if (item.Manufacturer == "Head")
                {
                    newSkiEquipment.Manufacturer = ManufacturerType.Head;
                }

                if (item.Manufacturer == "Atomic")
                {
                    newSkiEquipment.Manufacturer = ManufacturerType.Atomic;
                }

                if (item.Manufacturer == "Rossignol")
                {
                    newSkiEquipment.Manufacturer = ManufacturerType.Rossignol;
                }

                newSkiEquipment.Name = item.Name;
                newSkiEquipment.Price = item.Price;
                newSkiEquipment.Size = item.Size;
                outp.Add(newSkiEquipment);
            }

            return outp;
        }

        /// <inheritdoc/>
        public void ModSkiEquipment(SkiEquipment skiEquipmentToModify)
        {
            if (skiEquipmentToModify == null)
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            SkiEquipment clone2 = new SkiEquipment() { Name = skiEquipmentToModify.Name, Difficulty = skiEquipmentToModify.Difficulty, Manufacturer = skiEquipmentToModify.Manufacturer, Price = skiEquipmentToModify.Price, Size = skiEquipmentToModify.Size };
            SkiEquipment clone = new SkiEquipment();
            clone.CopyFrom(skiEquipmentToModify);
            if (this.editorService.EditSkiEquipment(clone) == true)
            {
                skiEquipmentToModify.CopyFrom(clone);
                var item = this.factory.Ctx.SkiEquipments.Where(x => clone2.Difficulty.ToString() == x.Difficulty && clone2.Size == x.Size && clone2.Price == x.Price && clone2.Manufacturer.ToString() == x.Manufacturer && clone2.Name == x.Name).SingleOrDefault();
                item.Name = skiEquipmentToModify.Name;
                item.Manufacturer = skiEquipmentToModify.Manufacturer.ToString();
                item.Size = skiEquipmentToModify.Size;
                item.Price = skiEquipmentToModify.Price;
                item.Difficulty = skiEquipmentToModify.Difficulty.ToString();
                this.factory.Ctx.SaveChanges();
                this.messengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("MODIFY CANCEL", "LogicResult");
            }
        }
    }
}
