using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        public Game Game { get; set; }
        public Hero Hero { get; set; }
        public Monster Enemy { get; set; }
 
        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.Hero = hero;
            this.Game = game;
            this.AddMonster("Squid", 9, 8, 20, 5, 11);
            this.AddMonster("Dragon", 11, 10, 21, 12, 8);
            this.AddMonster("Saber", 8, 12, 22, 8, 9);
            this.AddMonster("Lancer", 10, 7, 10, 6, 13);
            this.AddMonster("Caster", 12, 5, 15, 7, 10);
            this.AddMonster("Basakar", 20, 10, 15, 10, 9);

            var randomMonster = this.Monsters.OrderBy(monster => Guid.NewGuid()).First();
            Enemy = randomMonster;

        }

        public void AddMonster(string name, int strength, int defense, int hp, int gold, int speed) {
            var monster = new Monster(name, strength, defense, hp, gold, speed);
            this.Monsters.Add(monster);
        }
        
        public void Start() {

            //1) The last monster
            //var lastMonster = this.Monsters.Last();
            //var enemy = lastMonster;

            //2) The second monster
            // var enemy = this.Monsters[1];


            //3) The first monster with less than 20 hit points
            //var enemy = (from i in this.Monsters where i.CurrentHP <= 20 select i).First();

            //4) The first monster with a strength of at least 11
            //var enemy = (from i in this.Monsters where i.Strength >=11 select i).First();

            //5) A random monster
            //Random five = new Random();
            //int i = five.Next(0, 3);
            //var enemy = this.Monsters[i];

            
            Console.WriteLine("You've encountered a " + Enemy.Name + "! " + Enemy.Strength + " Strength/" + Enemy.Defense + " Defense/" +
            Enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (Hero.Speed >Enemy.Speed && input =="1")
            {
                Console.WriteLine("Your speed is higher than enemy's speed!"); 
                Console.WriteLine("Do you want to run away?");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Run away");

            }
            var choose = Console.ReadLine();
            if (choose == "1") {
                this.HeroTurn();
            }
            else if (choose == "2" && Hero.Speed > Enemy.Speed)
            {
                Console.WriteLine("Yeah! You escaped from the monster!");
                return;
            }
            if (Hero.Speed <= Enemy.Speed && input == "1") {
                this.HeroTurn();
            }
        }

        
        public void HeroTurn(){

           var compare = Hero.Strength - Enemy.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
                Enemy.CurrentHP -= damage;
           }
           else{
               damage = compare;
                Enemy.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(Enemy.CurrentHP <= 0){
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn(){

           int damage;
           var compare = Enemy.Strength - Hero.Defense;
           if(compare <= 0) {
               damage = 1;
               Hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               Hero.CurrentHP -= damage;
           }
           Console.WriteLine(Enemy.Name + " does " + damage + " damage!");
           if(Hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {

            this.Hero.Gold += Enemy.Gold;
            Console.WriteLine(Enemy.Name + " has been defeated! You win the battle! And you have earned " + Enemy.Gold + " gold from monster!" );
            Console.WriteLine("You have " + Hero.Gold + " in your bag right now!");
            Console.WriteLine("----------------------------------------------------");
            Game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}