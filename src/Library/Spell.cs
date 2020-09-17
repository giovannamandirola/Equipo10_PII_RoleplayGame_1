using System;

namespace Library
{
    public class Spell
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }

        public Spell (string name, int health, int damage)
        {
            this.Name = name;
            this.Damage = damage;
            this.Defense = health;
        }
    }
}