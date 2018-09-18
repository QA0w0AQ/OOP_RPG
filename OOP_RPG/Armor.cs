using System;
namespace OOP_RPG
{
    public class Armor:ITem
    {
        public Armor(string name, int defense) {
            this.Name = name;
            this.Defense = defense;
        }
        
        public string Name { get; set; }
        public int Defense { get; set; }
        public int OriginalValue { get; set ; }
        public int ResellValue { get; set; }
        public int ItemNumber { get; set; }

        public Armor(String name, int defense, int originalValue, int resellValue,int itemNumber)
        {
            this.Name = name;
            this.Defense = defense;
            this.OriginalValue = originalValue;
            this.ResellValue = resellValue;
            this.ItemNumber = itemNumber;
        }
    }
}