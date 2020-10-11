using System;
using System.Collections.Generic;
using System.Text;

namespace Items
{
    public class Item
    {
        // Health block
        public double HP { get; }
        public double HPRegen { get; }

        // Mana block
        public double Mana { get; }
        public double ManaRegen { get; }

        // Auto block
        public double AutoRangePerc { get; }

        // Movement block
        public double MovementSpeed { get; }
        public double MovementSpeedPercent { get; }

        // AD block
        public double BaseAD { get; }
        public double BonusAD { get; }
        public double BonusAttackSpeed { get; }
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

        // Misc block
        public double Tenacity { get; }
        public double PhysicalVamp { get; }
        public double Omnivamp { get; }
        public double HealAndShieldPower { get; }
        
        public bool GrievousWounds { get; }

        public Item()
        {

        }
        
    }
}
