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
            this.AddMonster("Squid", 9, 8, 20, 5);
            this.AddMonster("Dragon", 11, 10, 21, 10);
            this.AddMonster("Saber", 8, 12, 22, 8);
            this.AddMonster("Lancer", 10, 7, 10, 6);

            var randomMonster = this.Monsters.OrderBy(monster => Guid.NewGuid()).First();
            Enemy = randomMonster;

        }

        public void AddMonster(string name, int strength, int defense, int hp, int gold) {
            var monster = new Monster(name, strength, defense, hp, gold);
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
            if (input == "1") {
                this.HeroTurn();
            }
            else { 
                this.Game.Main();
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
            Console.WriteLine(Enemy.Name + " has been defeated! You win the battle! " +"And you has earned " + Hero.Gold + " gold from monster!" );
            Game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}