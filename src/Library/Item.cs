using System;

namespace Library
{
    public class Item
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }

        public Item (string name, int damage, int defense)
        {
            this.Name = name;
            this.Damage = damage;
            this.Defense = defense;
        }
    }
}