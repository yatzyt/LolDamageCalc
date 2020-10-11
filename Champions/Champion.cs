using System;
using System.Collections.Generic;
using System.Text;
using Items;
using System.Linq;

namespace Champions
{
    public class Champion
    {
        public string Name { get; internal set; }
        public int Level { get; set; }

        // Health block
        public double HP { get; internal set; }
        public double HPRegen { get; internal set; }
        public double Health_Growth { get; internal set; }
        public double HealthRegen_Growth { get; internal set; }

        // Resource block. Mana = energy
        public double Mana { get; internal set; }
        public double ManaRegen { get; internal set; }
        public double Mana_Growth { get; internal set; }
        public double ManaRegen_Growth { get; internal set; }
        public bool Manaless { get; internal set; }

        // Auto block
        public double AutoRange { get; internal set; }

        // Movement block
        public double MovementSpeed { get; internal set; }
        public double MovementSpeedPercent { get; internal set; }

        // AD block
        public double AD { get; internal set; }
        public double AD_Growth { get; internal set; }
        public double AttackSpeed { get; internal set; }
        public double AttackSpeed_Growth { get; internal set; }
        public double CritDamage { get; internal set; } // This is a multiplier
        public double CritChance { get; internal set; }
        public double Lethality { get; internal set; }
        public double ArmorPen { get; internal set; }
        public double BonusArmorPen { get; internal set; }

        // AP block
        public double AP { get; internal set; }
        public double AbilityHaste { get; internal set; }
        public double MagicPenFlat { get; internal set; }
        public double MagicPenPerc { get; internal set; }
        public double BonusMagicPenPerc { get; internal set; }

        // Resistances block
        public double Armor { get; internal set; }
        public double MR { get; internal set; }
        public double Armor_Growth { get; internal set; }
        public double MR_Growth { get; internal set; }

        // Misc block
        public double Tenacity { get; internal set; }
        public double PhysicalVamp { get; internal set; }
        public double Omnivamp { get; internal set; }
        public double HealAndShieldPower { get; internal set; }

        // Items
        public Dictionary<int, Item> Inventory { get; set; }

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

        public double ConvertHasteToCDR()
        {
            return 1 - (1 / (1 + (AbilityHaste / 100)));
        }

        public static object GetChampion(string championName)
        {
            Type t = Type.GetType(championName);
            if (championName.Contains("."))
            {
                championName = championName.Split('.').Last();
            }
            object[] args = new object[] { championName, 1 };
            return Activator.CreateInstance(t, args);
        }
            
    }
}
