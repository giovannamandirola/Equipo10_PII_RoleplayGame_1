using System;
using System.Collections.Generic;

namespace Library
{
    public class Character
    {
        public string Name { get; set; }
        private int _health;
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

        private int _damage;

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

        public string Type
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
        public int Totalhealth { get; }
        private List<Item> _items = new List<Item>();
        public List<Item> Items
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

        public List<Spell> SpellsBook
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
        public int Defense { get; set; }
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

        public void Attack(Character character)
        {
            if(character.Health < (this.Damage-character.Defense))
            {
                character.Health = 0;
            }
            if(this.Damage > character.Defense)
            {
                character.Health = character.Health + (character.Defense - this.Damage);
            }
        }

        public void AddItem(Item item)
        {
            if(!ExistItem(item))
            {
                this.Damage += item.Damage;
                this.Defense += item.Defense;
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
            int index = 0;
            this._items.ForEach(item => {
                if(item.Name == itemName)
                {
                    
                    this.Defense -= item.Defense;
                    this.Damage-= item.Damage;
                }
                else
                {
                    index++;
                }
            });
            this._items.Remove(_items[index]);
        }

        public void AddSpell(Spell spell)
        {
            if(!ExistSpell(spell) && this.Type == "mago")
            {
                this.Damage += spell.Damage;
                this.Defense += spell.Defense;
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
            int index = 0;
            this._spellsBook.ForEach(spell => {
                if(spell.Name == spellName)
                {
                    this.Defense -= spell.Defense;
                    this.Damage-= spell.Damage;
                }
                else
                {
                    index++;
                }
            });
            this._spellsBook.Remove(_spellsBook[index]);
        }
    }
}
