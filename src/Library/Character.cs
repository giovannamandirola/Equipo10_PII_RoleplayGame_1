using System;
using System.Collections.Generic;

namespace Library
{



    public class Character
    {
        private string Name { get; set; }
        private int _health { get; set; }
        private int Health 
        {
            get
            {
                return this._health;
            }

            set 
            {
                if(value >= 0)
                {
                    this._health = value;
                }
            }
        }

        private int _damage { get; set; }

        private int Damage 
        {
            get
            {
                return this._damage;
            }

            set 
            {
                if(value >= 0)
                {
                    this._damage = value;
                }
            }
        }
        private string _type { get; set; }

        private string Type
        {
            get
            {
                return this._type;
            }

            set
            {
                if(value.ToLower() == "mago" || value.ToLower() == "enano" || value.ToLower() == "elfo")
                {
                    this._type = value.ToLower();
                }
            }
        }
        private int Totalhealth { get; set; }
        private List<Item> _items = new List<Item>();
        private List<Item> Items
        {
            get
            {
                return this._items;
            }

            set
            {
                if(value != null)
                {
                    this._items = value;
                }
            }
        }

        public Character(string name, int health, int damage, string type, List<Item> items = null)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Type = type;
            this.Totalhealth = health;
            this.Items = items;
        }

        public void Cure()
        {
            this.Health = this.Totalhealth;
        }

        public void Atack(Character character)
        {
            character.Health -= this.Damage;
        }

        public void AddItem(Item item)
        {
            if(!ExistItem(item))
            {
                this.Damage += item.Damage;
                this.Health += item.Defense;
                this.Totalhealth += item.Defense;
                this._items.Add(item);
            }
        }

        public bool ExistItem(Item newItem)
        {
            bool res = false;

            this._items.ForEach(item => {
                if(item.Name == newItem.Name)
                {
                    res = true;
                }
            });

            return res;
        }

        public void DeleteItem(string itemName)
        {
            this._items.ForEach(item => {
                if(item.Name == itemName)
                {
                    this._items.Remove(item);
                    this.Health -= item.Defense;
                    this.Totalhealth -= item.Defense;
                }
            });
        }

    }
}
