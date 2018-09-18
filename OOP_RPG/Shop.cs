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
        public int itemNumber { get; private set; }

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
            var weapon1 = new Weapon("Sword", 3, 10, 5, 1);
            var weapon2 = new Weapon("Axe", 4, 12, 6, 2);
            var weapon3 = new Weapon("Longsword", 7, 20, 10, 3);

            this.WeaponsList.Add(weapon1);
            this.WeaponsList.Add(weapon2);
            this.WeaponsList.Add(weapon3);

            //armors storage
            var armor1 = new Armor("Wooden Armor",3, 10, 5, 4);
            var armor2 = new Armor("Metal Armor", 7, 20, 10, 5);


            this.ArmorsList.Add(armor1);
            this.ArmorsList.Add(armor2);

            //potion storage
            var potion1 = new Potion("Small Healing Potion", 5, 5, 3, 6);
            var potion2 = new Potion("Big Healing Potion", 5, 8, 4, 7);

            this.PotionsList.Add(potion1);
            this.PotionsList.Add(potion2);
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
                this.SellItem();
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
            
            foreach(var w in WeaponsList)
            {
                Console.WriteLine($"{w.ItemNumber}) " + w.Name + " ----- " + w.OriginalValue + " gold ");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Armors: ");
            foreach (var a in ArmorsList)
            {
                Console.WriteLine($"{a.ItemNumber}) " + a.Name + " ----- " + a.OriginalValue + " gold ");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Potions: ");
            foreach (var p in PotionsList)
            {
                Console.WriteLine($"{p.ItemNumber}) " + p.Name + " ----- " + p.OriginalValue + " gold ");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Enter 'r' to return to Top Menu");
            var select = Console.ReadLine();
            var number = Int32.TryParse(select, out int itemNumber);
            if (number)
            {
                this.Buy(itemNumber);
            }
            else if (select == "r")
            {
                this.Menu();
            }
        }

        private void Buy(int itemNumber)
        {
            Console.WriteLine("You have "  + Game.hero.Gold + " gold right now." + "Do you want purchase this item? (Y/N)");
            var input = Console.ReadLine();

            var weapon = this.WeaponsList.Where(w => w.ItemNumber == itemNumber).FirstOrDefault();
            if (weapon!=null)
            {
                if (Game.hero.Gold >=weapon.OriginalValue)
                {
                    this.Game.hero.Gold -= weapon.OriginalValue;
                    this.Game.hero.WeaponsBag.Add(weapon);
                }
                else
                {
                    Console.WriteLine("You dont have enough money!");
                    Menu();
                }
            }

            var armor = this.ArmorsList.Where(a => a.ItemNumber == itemNumber).FirstOrDefault();
            if (armor != null)
            {
                if (Game.hero.Gold >= armor.OriginalValue)
                {
                    this.Game.hero.Gold -= armor.OriginalValue;
                    this.Game.hero.ArmorsBag.Add(armor);
                }
                else
                {
                    Console.WriteLine("You dont have enough money!");
                    Menu();
                }
            }

            var potion = this.PotionsList.Where(p => p.ItemNumber == itemNumber).FirstOrDefault();
            if (potion != null)
            {
                if (Game.hero.Gold >= potion.OriginalValue)
                {
                    this.Game.hero.Gold -= potion.OriginalValue;
                    this.Game.hero.PotionBag.Add(potion);
                }
                else
                {
                    Console.WriteLine("You dont have enough money!");
                    Menu();
                }
            }

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

        public void SellItem()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach (var w in Game.hero.WeaponsBag)
            {
                Console.WriteLine($"{w.ItemNumber}) "+ w.Name + " ResellValue is " + w.ResellValue + " gold");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Armor: ");
            foreach (var a in Game.hero.ArmorsBag)
            {
                Console.WriteLine($"{a.ItemNumber}) " + a.Name + " ResellValue is " + a.ResellValue + " gold");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Potion: ");
            foreach (var p in Game.hero.PotionBag)
            {
                Console.WriteLine($"{p.ItemNumber}) " + p.Name + " ResellValue is " + p.ResellValue + " gold");
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
            Console.WriteLine("You have " + Game.hero.Gold + " gold right now." + "Press any key to return to main menu.");
            var input = Console.ReadLine();
            var weapon = this.Game.hero.WeaponsBag.Where(w => w.ItemNumber == itemNumber).FirstOrDefault();
            if (weapon != null)
            {

                    this.Game.hero.Gold += weapon.ResellValue;
                    this.Game.hero.WeaponsBag.Remove(weapon);
                  
            }

            var armor = this.ArmorsList.Where(a => a.ItemNumber == itemNumber).FirstOrDefault();
            if (armor != null)
            {

                    this.Game.hero.Gold += armor.ResellValue;
                    this.Game.hero.ArmorsBag.Remove(armor);
                    
            }

            var potion = this.PotionsList.Where(p => p.ItemNumber == itemNumber).FirstOrDefault();
            if (potion != null)
            {
                    this.Game.hero.Gold += potion.ResellValue;
                    this.Game.hero.PotionBag.Remove(potion);
                    
            }

            if (input == "Y" || input == "y")
            {
                Console.WriteLine("Nice! You sell it and you get gold!");
                Console.WriteLine("----------------------------------------------------");
                this.Menu();
            }
            else
            {
                this.Menu();
            }
        }
    }
}
