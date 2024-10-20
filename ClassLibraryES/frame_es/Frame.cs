using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace ClassLibraryES
{
    public class Frame
    {
        private System.Guid id;
        private string name;
        private System.Collections.Generic.List<Slot> slots;
        private Frame? parent;

        /// <summary>
        /// Получить уникальный id фрейма
        /// </summary>
        public System.Guid Id { get => id; }

        /// <summary>
        /// Получить имя фрейма
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Получить список свойств\слотов фрейма
        /// </summary>
        public List<Slot> Slots { get => slots; }

        /// <summary>
        /// Получить родительский фрейм.
        /// В случае отсутствия родителя возвращается null.
        /// </summary>
        public Frame? Parent { get => parent; }

        /// <summary>
        /// Конкструктор фрейма
        /// </summary>
        public Frame() 
        {
            this.id = Guid.NewGuid();
            this.name = string.Empty;
            this.slots = new List<Slot>();
            this.parent = null;
        }
        /// <summary>
        /// Конструктор фрейма
        /// </summary>
        /// <param name="name">имя фрейма</param>
        /// <param name="parent">родительский фрейм</param>
        public Frame(string name, Frame? parent=null)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.slots = new List<Slot>();
            this.parent = parent;
        }

        /// <summary>
        /// Добавить слот\свойство
        /// </summary>
        /// <param name="slot">добавляемый слот\свойство</param>
        public void AddSlot(Slot slot)
        {
            this.slots.Add(slot);
        }

        /// <summary>
        /// Добавить слот\свойство
        /// </summary>
        /// <param name="name">имя добавляемого слота\свойства</param>
        /// <param name="value">значение добавляемого слота\свойства</param>
        public void AddSlot(string name, string value)
        {
            this.slots.Add(new Slot(name,value));
        }

        /// <summary>
        /// Удалить слот\свойство
        /// </summary>
        /// <param name="slotName">имя удаляемого слота\свойства</param>
        public void RemoveSlot(string slotName) 
        { 
            foreach (var slot in slots)
            {
                if (slot.Name == slotName)
                    slots.Remove(slot);
            }
        }

        /// <summary>
        /// Удалить слот\свойство
        /// </summary>
        /// <param name="id">id удаляемого слота\свойства</param>
        public void RemoveSlot(Guid id)
        {
            foreach (var slot in slots)
            {
                if (slot.Id == id)
                    slots.Remove(slot);
            }
        }
    }
}