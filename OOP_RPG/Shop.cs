using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        public List<Weapon> WeaponsList { get; set; }
        public List<Armor> ArmorsList { get; set; }
        public List<Potion> PotionsList { get; set; }
        public Game Game { get; set; }
        public Hero Hero { get; set; }

        public Shop (Game game)
        {
            this.WeaponsList = new List<Weapon>();
            this.ArmorsList = new List<Armor>();
            this.PotionsList = new List<Potion>();
            this.Game = game;
            Storage();
        }

        public void Storage()
        {   
            //weapons storage
            var weapon1 = new Weapon("Sword", 3, 10, 2);
            var weapon2 = new Weapon("Axe", 4, 12, 3);
            var weapon3 = new Weapon("Longsword", 7, 20, 5);

            this.WeaponsList.Add(weapon1);
            this.WeaponsList.Add(weapon2);
            this.WeaponsList.Add(weapon3);

            //armors storage
            var armor1 = new Armor("Wooden Armor",3, 10, 2);
            var armor2 = new Armor("Metal Armor", 7, 20, 5);


            this.ArmorsList.Add(armor1);
            this.ArmorsList.Add(armor2);

            //potion storage
            var potion1 = new Potion("Healing Potion", 5, 5, 2);

            this.PotionsList.Add(potion1);
        }
        
        public void Menu()
        {
            Console.WriteLine("Welcome to my shop! What would you like to do?");
            Console.WriteLine("1. Buy Item");
            Console.WriteLine("2. Sell Item");
            Console.WriteLine("3. Return to Game Menu");
            var select = Console.ReadLine();
            if (select == "1")
            {
                this.ShowInventory();
            }
            else if (select == "2")
            {
                this.BuyfromUser();
            }
            else
            {
                this.Game.Main();
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            var num = 1;
            foreach(var w in WeaponsList)
            {
                Console.WriteLine($"{num} " + w.Name + " ----- " + w.OriginalValue + " gold ");
                num++;
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Armors: ");
            foreach (var a in ArmorsList)
            {
                Console.WriteLine($"{num} " + a.Name + " ----- " + a.OriginalValue + " gold ");
                num++;
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Potions: ");
            foreach (var p in PotionsList)
            {
                Console.WriteLine($"{num} " + p.Name + " ----- " + p.OriginalValue + " gold ");
                num++;
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Enter 'r' to return to Top Menu");
            var select = Console.ReadLine();
            var number = Int32.TryParse(select, out int itemNumber);
            if (number)
            {
                this.Sell(itemNumber);
            }
            else if (select == "r")
            {
                this.Menu();
            }
        }

        private void Sell(int itemNumber)
        {
            Console.WriteLine("You have "  + Game.hero.Gold + " gold right now." + "Do you want purchase this item? (Y/N)");
            var input = Console.ReadLine();
            if (input == "Y" || input == "y")
            {
                Console.WriteLine("Congratulation! You got it!");
                Console.WriteLine("----------------------------------------------------");
                this.Menu();
            }
            else
            {
                this.Menu();
            }
        }

        public void BuyfromUser()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach (var w in Hero.WeaponsBag)
            {
                Console.WriteLine(w.Name + " of " + w.ResellValue + " gold");
            }
            Console.WriteLine("Armor: ");
            foreach (var a in Hero.ArmorsBag)
            {
                Console.WriteLine(a.Name + " of " + a.ResellValue + " gold");
            }
            Console.WriteLine("Potion: ");
            foreach (var p in Hero.PotionBag)
            {
                Console.WriteLine(p.Name + " of " + p.ResellValue + " gold");
            }
            Console.WriteLine("----------------------------------------------------");


        }



    }
}
