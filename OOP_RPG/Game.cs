using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Game
    {
        public Hero hero { get; set; }
        public Shop Shop { get; set; }
        
        public Game() {
            this.hero = new Hero();
            this.Shop = new Shop(this);
        }
            
        public void Start() {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");
            this.hero.Name = Console.ReadLine();
            Console.WriteLine("Hello " + hero.Name);
            this.Main();
        }
        
        public void Main() {
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Fight Monster");
            Console.WriteLine("4. Go to the shop");
            Console.WriteLine("5. Equipping Weapons & Armor");
            Console.WriteLine("6. Healing Potion");
            var input = Console.ReadLine();
            if (input == "1") {
                this.Stats();
            }
            else if (input == "2") {
                this.Inventory();
            }
            else if (input == "3") {
                this.Fight();
            }
            else if (input == "4")
            {
                this.Shop.Menu();
            }
            else if (input == "5")
            {
                this.EquipItems();
            }
            else if (input == "6")
            {
                this.UsePotion();
            }
            else {
                return;
            }
        }



        public void Stats() {
            hero.ShowStats();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }
        
        public void Inventory(){
            hero.ShowInventory();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }
        
        public void Fight(){
            var fight = new Fight(this.hero, this);
            fight.Start();
        }
        
        public void EquipItems()
        {
            Console.WriteLine("*****  Equipping Weapons & Armor ******");
            Console.WriteLine("Weapons: ");
            foreach (var w in this.hero.WeaponsBag)
            {
                Console.WriteLine($"{w.ItemNumber}) " + w.Name + " of " + w.Strength + " Strength");
            }
            Console.WriteLine("Armor: ");
            foreach (var a in this.hero.ArmorsBag)
            {
                Console.WriteLine($"{a.ItemNumber}) " + a.Name + " of " + a.Defense + " Defense");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Enter 'r' to return to Top Menu");
            var select = Console.ReadLine();
            var number = Int32.TryParse(select, out int itemNumber);
            if (number)
            {
                this.hero.EquipWeapon();
                var input = Console.ReadLine();
                var a = Int32.TryParse(input, out int some);
                if (a)
                {
                    this.Main();
                }
                else
                {
                    Main();
                }
            }
            else if (select == "r")
            {
                this.Main();
            }
        }


        private void UsePotion()
        {
            Console.WriteLine("Potion: ");
            foreach (var p in this.hero.PotionBag)
            {
                Console.WriteLine($"{p.ItemNumber}) " + p.Name + " of " + p.HP + " HP value");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Enter 'r' to return to Top Menu");
            var select = Console.ReadLine();
            var number = Int32.TryParse(select, out int itemNumber);
            if (number)
            {
                this.hero.UsingPotion();
                var input = Console.ReadLine();
                var a = Int32.TryParse(input, out int some);
                if (a)
                {
                    this.Main();
                }
                else
                {
                    Main();
                }
            }
            else if (select == "r")
            {
                this.Main();
            }
        }
    }
}  