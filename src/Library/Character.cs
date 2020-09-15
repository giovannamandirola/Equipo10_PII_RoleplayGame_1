using System;

namespace Library
{



    public class Character
    {
        private string Name{get;set;}
        private int Health{get;set;}
        private int Damage{get;set;}
        private string Type{get;set;}

        private int Totalhealth{get;set;}

        public Character(string name, int health, int damage,string type)
        {
            this.Name=name;
            this.Health=health;
            this.Damage=damage;
            this.Type=type;
            this.Totalhealth=health;
        }

        public void Cure()
        {
            this.Health=this.Totalhealth;
        }

        

    }
}
