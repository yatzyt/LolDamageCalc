using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Champion
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Health { get; set; }
        public string HealthRegen { get; set; }
        public string Mana { get; set; }
        public string ManaRegen { get; set; }
        public string Manaless { get; set; }
        public string AutoRange { get; set; }
        public string MovementSpeed { get; set; }
        public string AttackDamage { get; set; }
        public string AttackSpeed { get; set; }
        public string Armor { get; set; }
        public string MagicResist { get; set; }
        public string Health_Growth { get; set; }
        public string HealthRegen_Growth { get; set; }
        public string Mana_Growth { get; set; }
        public string ManaRegen_Growth { get; set; }
        public string AD_Growth { get; set; }
        public string AS_Growth { get; set; }
        public string Armor_Growth { get; set; }
        public string MR_Growth { get; set; }
        public string AbilityHaste { get; set; }

        /// <summary>
        /// Note: does not take into account Armor and MR when outputing damage numbers.
        /// </summary>
        public Champion()
        {
        }
        public Champion(string name)
        {
            this.Name = name;
        }

        public double CalculateHealth(int n)
        {
            return Double.Parse(Health) + Double.Parse(Health_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateHealthRegen(int n)
        {
            return Double.Parse(HealthRegen) + Double.Parse(HealthRegen_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateMana(int n)
        {
            return Double.Parse(Mana) + Double.Parse(Mana_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateManaRegen(int n)
        {
            return Double.Parse(ManaRegen) + Double.Parse(ManaRegen_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateAD(int n) //TODO: add items to these functions
        {
            return Double.Parse(AttackDamage) + Double.Parse(AD_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateBonusAS(int n)
        {
            if (Name == "Gnar Mini")
                return Double.Parse(AS_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1) + 0.055);
            else
                return Double.Parse(AS_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateArmor(int n)
        {
            return Double.Parse(Armor) + Double.Parse(Armor_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateMR(int n)
        {
            return Double.Parse(MagicResist) + Double.Parse(MR_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public string CalculateRange(int n)
        {
            if (Name == "Tristana")
                return (8 * (n - 1) + Double.Parse(AutoRange)).ToString();
            else if (Name == "Gnar Mini")
                return (Double.Parse(AutoRange) + 50 + 5.9 * (n - 1)).ToString();
            else
                return AutoRange;
        }

            
    }
}
