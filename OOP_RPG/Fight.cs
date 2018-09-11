using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        public Game game { get; set; }
        public Hero hero { get; set; }
 
        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("Dragon", 12, 10, 25);
            this.AddMonster("Saber", 8, 12, 22);
            this.AddMonster("Lancer", 10, 7, 10);
        }
        
        public void AddMonster(string name, int strength, int defense, int hp) {
            var monster = new Monster();

            monster.Name = name;
            monster.Strength = strength;
            monster.Defense = defense;
            monster.OriginalHP = hp;
            monster.CurrentHP = hp;
            this.Monsters.Add(monster);
        }
        
        public void Start() {

            //1) The last monster
            //var lastMonster = this.Monsters.Last();
            //var enemy = (from p in this.Monsters select p).Last();

            //2) The second monster
            // var enemy = this.Monsters[1];


            //3) The first monster with less than 20 hit points
            //var enemy = (from i in this.Monsters where i.CurrentHP <= 20 select i).FirstOrDefault();

            //4) The first monster with a strength of at least 11
            //var enemy = (from i in this.Monsters where i.Strength >=11 select i).FirstOrDefault();

            //5) A random monster
            //Random five = new Random();
            //int i = five.Next(0, 3);
            //var enemy = this.Monsters[i];

            var enemy = this.Monsters[0];
            Console.WriteLine("You've encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" + enemy.Defense + " Defense/" + 
            enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn(enemy);
            }
            else { 
                this.game.Main();
            }
        }
        
        public void HeroTurn(Monster monster){
           var enemy = monster;
           var compare = hero.Strength - enemy.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               enemy.CurrentHP -= damage;
           }
           else{
               damage = compare;
               enemy.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(enemy.CurrentHP <= 0){
               this.Win(enemy);
           }
           else
           {
               this.MonsterTurn(enemy);
           }
           
        }
        
        public void MonsterTurn(Monster monster){
           var enemy = monster;
           int damage;
           var compare = enemy.Strength - hero.Defense;
           if(compare <= 0) {
               damage = 1;
               hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               hero.CurrentHP -= damage;
           }
           Console.WriteLine(enemy.Name + " does " + damage + " damage!");
           if(hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win(Monster monster) {
            var enemy = monster;
            Console.WriteLine(enemy.Name + " has been defeated! You win the battle!");
            game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}