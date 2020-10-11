using System;
using System.Collections.Generic;
using System.Text;
using Items;

namespace Champions
{
    public class Champion
    {
        public string Name { get; }
        public int Level { get; }

        // Health block
        public double HP { get; }
        public double HPRegen { get; }
        public double Health_Growth { get; }
        public double HealthRegen_Growth { get; }

        // Resource block. Mana = energy
        public double Mana { get; }
        public double ManaRegen { get; }
        public double Mana_Growth { get; }
        public double ManaRegen_Growth { get; }
        public bool Manaless { get; }

        // Auto block
        public double AutoRange { get; }

        // Movement block
        public double MovementSpeed { get; }
        public double MovementSpeedPercent { get; }

        // AD block
        public double AD { get; }
        public double AD_Growth { get; }
        public double AttackSpeed { get; }
        public double AttackSpeed_Growth { get; }
        public double CritDamage { get; }
        public double CritChance { get; }
        public double Lethality { get; }
        public double ArmorPen { get; }
        public double BonusArmorPen { get; }

        // AP block
        public double AP { get; }
        public double AbilityHaste { get; }
        public double MagicPenFlat { get; }
        public double MagicPenPerc { get; }
        public double BonusMagicPenPerc { get; }

        // Resistances block
        public double Armor { get; }
        public double MR { get; }
        public double Armor_Growth { get; }
        public double MR_Growth { get; }

        // Misc block
        public double Tenacity { get; }
        public double PhysicalVamp { get; }
        public double Omnivamp { get; }
        public double HealAndShieldPower { get; }

        // Items
        public List<Item> Inventory { get; set; }

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
            return HP + Health_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }
        public double CalculateHealthRegen(int n)
        {
            return HPRegen + HealthRegen_Growth * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateMana(int n)
        {
            return Mana + Mana_Growth * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateManaRegen(int n)
        {
            return ManaRegen + ManaRegen_Growth * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateAD(int n) //TODO: add items to these functions
        {
            return AD + AD_Growth * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateBonusAD(int n)
        {
            return 0;
        }
        public double CalculateLethality(int n)
        {
            return 0;
        }
        public double CalculatePercentArmorPen(int n)
        {
            return 0;
        }
        public double CalculatePercentBonusArmorPen(int n)
        {
            return 0;
        }
        public double CalculateAP(int n)
        {
            return 0;
        }
        public double CalculateFlatMagicPen(int n)
        {
            return 0;
        }
        public double CalculatePercentMagicPen(int n)
        {
            return 0;
        }
        public double CalculatePercentBonusMagicPen(int n)
        {
            return 0;
        }
        public double CalculateBonusAS(int n)
        {
            if (Name == "Gnar Mini")
                return AttackSpeed_Growth * (n - 1) * (0.7025 + 0.0175 * (n - 1) + 0.055);
            else
                return AttackSpeed_Growth * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateArmor(int n)
        {
            return Armor + Armor_Growth * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateMR(int n)
        {
            return MR + MR_Growth * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateRange(int n)
        {
            if (Name == "Tristana")
                return 8 * (n - 1) + AutoRange;
            else if (Name == "Gnar Mini")
                return AutoRange + 50 + 5.9 * (n - 1);
            else
                return AutoRange;
        }

        public object GetChampion(string championName)
        {
            Type t = Type.GetType(championName);
            return Activator.CreateInstance(t);
        }
            
    }
}
