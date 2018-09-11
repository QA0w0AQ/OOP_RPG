using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }

        public Monster(String Name, int Strength, int Defense, int OriginalHP, int CurrentHP) {
            this.Name = Name;
            this.Defense = Defense;
            this.Strength = Strength;
            this.OriginalHP = OriginalHP;
            this.CurrentHP = CurrentHP;
        }
    }
}