﻿using System;
using Library;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Spell> spellBook = new List<Spell>();
            Spell spell1 = new Spell("Hezhico 1", 10, 45);
            spellBook.Add(spell1);
            Character wizard = new Character("Mago Gms", 100, 100, "mago", null, spellBook);
            Item item1 = new Item("Bastón mágico", 20, 20);
            Item item2 = new Item("Capa", 15, 35);
            wizard.AddItem(item1);
            wizard.AddItem(item2);

            Console.WriteLine(wizard.Damage);
            Console.WriteLine(wizard.Health);

            Character elf = new Character("Elfpro", 100, 100, "elfo");
            Item ropaje = new Item("Ropaje", 0, 5);
            Item hacha = new Item("Hacha", 30, 0);
            elf.AddItem(ropaje);
            elf.AddItem(hacha);
            
            Character dwarf = new Character("Enano Oscar", 100, 100, "enano");
            Item sword = new Item("Escarbadiente", 20, 20);
            Item hat= new Item("re fachero", 15, 35);
            dwarf.AddItem(sword);
            dwarf.AddItem(hat);

            Console.WriteLine(dwarf.Damage);
            Console.WriteLine(dwarf.Health);
        }
    }
}

