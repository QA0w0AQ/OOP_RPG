using System;
namespace OOP_RPG
{
    public class Weapon:ITem
    {
        public Weapon(string name, int strength) {
            this.Name = name;
            this.Strength = strength;
        }
        
        public string Name { get; set; }
        public int Strength { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }
        public int ItemNumber { get; set; }

        public Weapon(String name, int strength, int originalValue, int resellValue,int itemNumber)
        {
            this.Name = name;
            this.Strength =strength;
            this.OriginalValue = originalValue;
            this.ResellValue = resellValue;
            this.ItemNumber = itemNumber;
        }
    }
}