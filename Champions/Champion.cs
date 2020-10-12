using System;
using System.Collections.Generic;
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
        public bool Energy { get; internal set; }

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
        public double BonusArmor { get; internal set; }
        public double MR { get; internal set; }
        public double BonusMR { get; internal set; }
        public double Armor_Growth { get; internal set; }
        public double MR_Growth { get; internal set; }

        // Damage Reduction block, seperate from what armor and mr provides
        public double PhysDamageReduction { get; internal set; }
        public double FlatPhysDamageReduction { get; internal set; }
        public double MagicDamageReduction { get; internal set; }
        public double MostDamageReduction { get; internal set; }

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

        public double CalculateHealth() 
        {
            return HP + Health_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }

        public double CalculateHealthRegen()
        {
            return HPRegen + HealthRegen_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }

        public double CalculateMana()
        {
            return Mana + Mana_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }

        public double CalculateManaRegen()
        {
            return ManaRegen + ManaRegen_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }

        public double CalculateAD() //TODO: add items to these functions
        {
            return AD + AD_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }

        public double CalculateBonusAD()
        {
            return 0;
        }

        public double CalculateLethality()
        {
            return 0;
        }

        public double CalculatePercentArmorPen()
        {
            return 0;
        }

        public double CalculatePercentBonusArmorPen()
        {
            return 0;
        }

        public double CalculateAP()
        {
            return 0;
        }

        public double CalculateFlatMagicPen()
        {
            return 0;
        }

        public double CalculatePercentMagicPen()
        {
            return 0;
        }

        public double CalculatePercentBonusMagicPen()
        {
            return 0;
        }

        public double CalculateBonusAS()
        {
            if (Name == "Gnar Mini")
                return AttackSpeed_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1) + 0.055);
            else
                return AttackSpeed_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }

        public double CalculateArmor()
        {
            return Armor + Armor_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }

        public double CalculateMR()
        {
            return MR + MR_Growth * (Level - 1) * (0.7025 + 0.0175 * (Level - 1));
        }

        public double CalculateRange()
        {
            if (Name == "Tristana")
                return 8 * (Level - 1) + AutoRange;
            else if (Name == "Gnar Mini")
                return AutoRange + 50 + 5.9 * (Level - 1);
            else
                return AutoRange;
        }

        public double CalculateBonusArmor()
        {
            return 0;
        }

        public double CalculateBonusMR()
        {
            return 0;
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
