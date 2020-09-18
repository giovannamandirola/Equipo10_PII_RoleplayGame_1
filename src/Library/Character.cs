using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que representa a los personajes
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Nombre del personaje
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Vida actual del personaje
        /// </summary>
        private int _health;
        public int Health 
        {
            get
            {
                return this._health;  // Con esto resolvemos el obtener el valor total de vida de un personaje
            }

            set 
            {
                // Esto es para que no sea posible que un personaje tenga menos de 0 de vida
                if(value >= 0)
                {
                    this._health = value;
                }
            }
        }

        /// <summary>
        /// Daño del personaje
        /// </summary>
        private int _damage;

        public int Damage 
        {
            get
            {
                return this._damage;  // Con esto resolvemos el obtener el valor total de ataque de un personaje
            }

            set 
            {
                // Esto es para que no sea posible que un personaje tenga menos de 0 de daño
                if(value >= 0)
                {
                    this._damage = value;
                }
            }
        }

        /// <summary>
        /// Tipo del personaje (mago, enano, elfo)
        /// </summary>
        private string _type { get; set; }

        public string Type
        {
            get
            {
                return this._type;
            }

            set
            {
                // Si el tipo es uno de los que definimos como válidos, lo setea, sino no
                if(value.ToLower() == "mago" || value.ToLower() == "enano" || value.ToLower() == "elfo")
                {
                    this._type = value.ToLower();
                }
            }
        }

        /// <summary>
        /// Vida total del personaje
        /// </summary>
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


        /// <summary>
        /// Libro de hechizos, solo se usa cuando el tipo es "mago"
        /// </summary>
        private List<Spell> _spellsBook = new List<Spell>();

        public List<Spell> SpellsBook
        {
            get
            {
                return this._spellsBook;
            }

            set
            {
                // Solo permite el uso de Spells no nulos y cuando el personaje es mago
                if(value != null && this.Type == "mago")
                {
                    value.ForEach(spell => {
                        this.AddSpell(spell);
                    });
                }
            }
        }

        /// <summary>
        /// Defensa del personaje
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Hace que el personaje recupere su vida total
        /// </summary>
        public void Cure()
        {
            // Acá decidimos almacenar el atributo TotalHealth la vida total, entonces para curar simplemente seteamos ese valor en el atributo Health
            this.Health = this.Totalhealth;
        }

        /// <summary>
        /// Hace que el personaje ataque al personaje indicado en el parámetro
        /// </summary>
        public void Attack(Character character)
        {
            if(this.Damage > character.Defense) // Se realiza el ataque solo si es mayor a la defensa de la victima
            {
                character.Health = character.Health + (character.Defense - this.Damage);
            }
        }

        /// <summary>
        /// Añade un item al personaje, siempre y cuando no lo tenga
        /// </summary>
        public void AddItem(Item item)
        {
            if(!ExistItem(item)) // Solo lo agrega si no lo tiene
            {
                // Le suma las caracteristicas del item al personaje
                this.Damage += item.Damage; 
                this.Defense += item.Defense;
                // Añade el item a la lista de items
                this._items.Add(item);
            }
        }

        /// <summary>
        /// Dado un item, retorna true si el personaje ya lo tiene, y false en caso contrario
        /// </summary>
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

        /// <summary>
        /// Dado el nombre de un item, busca si hay un item con ese nombre y si lo hay lo elimina
        /// </summary>
        public void DeleteItem(string itemName)
        {
            this._items.ForEach(item => {
                if(item.Name == itemName)
                {
                    this._items.Remove(item);
                    this.Defense -= item.Defense;
                    this.Damage-= item.Damage;
                }
            });
        }

        /// <summary>
        /// Añade un spell al personaje, siempre y cuando no lo tenga y sea del tipo mago
        /// </summary>
        public void AddSpell(Spell spell)
        {
            if(!ExistSpell(spell) && this.Type == "mago")
            {
                this.Damage += spell.Damage;
                this.Defense += spell.Defense;
                this._spellsBook.Add(spell);
            }
        }

        /// <summary>
        /// Dado un spell, retorna true si el personaje ya lo tiene, y false en caso contrario
        /// </summary>
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


        /// <summary>
        /// Dado el nombre de un spell, busca si hay un item con ese nombre y si lo hay lo elimina
        /// </summary>
        public void DeleteSpell(string spellName)
        {
            this._spellsBook.ForEach(spell => {
                if(spell.Name == spellName)
                {
                    this._spellsBook.Remove(spell);
                    this.Defense -= spell.Defense;
                    this.Damage-= spell.Damage;
                }
            });
        }
    }
}
