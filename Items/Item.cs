using System;
using System.Collections.Generic;
using System.Text;

namespace Items
{
    class Item
    {
        public double HP { get; }
        public double HPRegen { get; }
        public double Armor { get; }
        public double MR { get; }
        public double MovementSpeed { get; }
        public double MovementSpeedPercent { get; }
        public double Mana { get; }
        public double ManaRegen { get; }
        public double BonusAD { get; }
        public double BaseAD { get; }
        public double CritDamage { get; }
        public double CritChance { get; }
        public double BonusAttackSpeed { get; }
        public double Lethality { get; }
        public double ArmorPen { get; }
        public double BonusArmorPen { get; }
        public double AP { get; }
        public double AbilityHaste { get; }
        public double Tenacity { get; }
        public double MagicPenFlat { get; }
        public double MagicPenPerc { get; }
        public double BonusMagicPenPerc { get; }
        public double PhysicalVamp { get; }
        public double Omnivamp { get; }
        public double HealAndShieldPower { get; }
        
        public bool GrievousWounds { get; }

        public Item()
        {

        }
        
    }
}
