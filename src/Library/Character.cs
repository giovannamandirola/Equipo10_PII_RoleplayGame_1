using System;
using System.Collections.Generic;

namespace Library
{
    public class Character
    {
        private string Name { get; set; }
        private int _health { get; set; }
        public int Health 
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

        public int Damage 
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
                    value.ForEach(item => {
                        this.AddItem(item);
                    });
                }
            }
        }

        private List<Spell> _spellsBook = new List<Spell>();

        private List<Spell> SpellsBook
        {
            get
            {
                return this._spellsBook;
            }

            set
            {
                if(value != null && this.Type == "mago")
                {
                    value.ForEach(spell => {
                        this.AddSpell(spell);
                    });
                }
            }
        }

        public Character(string name, int health, int damage, string type, List<Item> items = null, List<Spell> spellsBook = null)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Type = type;
            this.Totalhealth = health;
            this.Items = items;
            this.SpellsBook = spellsBook;
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

        public void AddSpell(Spell spell)
        {
            if(!ExistSpell(spell) && this.Type == "mago")
            {
                this.Damage += spell.Damage;
                this.Health += spell.Defense;
                this.Totalhealth += spell.Defense;
                this._spellsBook.Add(spell);
            }
        }

        public bool ExistSpell(Spell newSpell)
        {
            bool res = false;

            this._spellsBook.ForEach(spell => {
                if(spell.Name == newSpell.Name)
                {
                    res = true;
                }
            });

            return res;
        }

        public void DeleteSpell(string spellName)
        {
            this._spellsBook.ForEach(spell => {
                if(spell.Name == spellName)
                {
                    this._spellsBook.Remove(spell);
                    this.Health -= spell.Defense;
                    this.Totalhealth -= spell.Defense;
                }
            });
        }
    }
}
