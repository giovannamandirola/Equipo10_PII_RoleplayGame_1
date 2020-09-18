using System;

namespace Library
{
    public class Spell
    {
        public string Name { get; set; }
        private int _damage;
        public int Damage 
        { 
            get
            {
                return this._damage;
            }
            set
            {
                if(value>=0)
                {
                    this._damage = value;
                }
            } 
        }
        private int _defense;
        public int Defense
        { 
            get
            {
                return this._defense;
            }
            set
            {
                if(value>=0)
                {
                    this._defense = value;
                }
            } 
        }

        public Spell (string name, int damage, int defense)
        {
            this.Name = name;
            this.Damage = damage;
            this.Defense = defense;
        }
    }
}