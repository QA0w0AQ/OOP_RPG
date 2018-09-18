using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero() {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionBag = new List<Potion>();
            this.Strength = 20;
            this.Defense = 20;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 50;
            this.Speed = 10;
        }
        
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }
        public int Speed { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public Potion EquippedPotion { get; set; }

        public List<Armor> ArmorsBag { get; set;}
        public List <Weapon> WeaponsBag { get; set; }
        public List<Potion> PotionBag { get; set; }
        
        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Speed: " + this.Speed);
            Console.WriteLine("Gold: " + this.Gold);
        }
        
        public void ShowInventory() {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach(var w in this.WeaponsBag){
                Console.WriteLine(w.Name + " of " + w.Strength + " Strength");
            }
            Console.WriteLine("Armor: ");
            foreach(var a in this.ArmorsBag){
                Console.WriteLine(a.Name + " of " + a.Defense + " Defense");
            }
            Console.WriteLine("Potion: ");
            foreach (var p in this.PotionBag)
            {
                Console.WriteLine(p.Name + " of " + p.HP + " Defense");
            }
            Console.WriteLine("----------------------------------------------------");
        }
        
        public void EquipWeapon() {
            if(WeaponsBag.Any()) {
                this.EquippedWeapon = this.WeaponsBag[0];
                this.Strength += EquippedWeapon.Strength;
                Console.WriteLine($"{this.EquippedWeapon.Name} is equiped!");
            }
            else if (ArmorsBag.Any())
            {
                this.EquippedArmor = this.ArmorsBag[0];
                this.Defense += EquippedArmor.Defense;
                Console.WriteLine($"{this.EquippedArmor.Name} is equiped!");
            }
            Console.WriteLine("Now, you become stonger!\nPress any key to return to main menu.");

        }
        
        public void UsingPotion()
        {
            if(PotionBag.Any())
            {
                if (CurrentHP >= OriginalHP)
                {
                    Console.WriteLine("You have full Hp!");
                }
                else  {
                    this.EquippedPotion = this.PotionBag[0];
                    CurrentHP += EquippedPotion.HP;
                    Console.WriteLine($"Used {this.EquippedPotion.Name}, you hp get improved!");
                    if (CurrentHP > OriginalHP)
                    {
                        CurrentHP = OriginalHP;
                        Console.WriteLine("You have full hp right now!");
                    }
                    else
                    {
                        CurrentHP = CurrentHP;
                    } 
                }
                Console.WriteLine("Press any key to return to main menu.");
            }
        }
    }
}