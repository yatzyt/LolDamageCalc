using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Ashe : Champion
    {
        public Ashe(string name = "Ashe", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 570.0;
            Health_Growth        = 87.0;
            HPRegen              = 3.5;
            HealthRegen_Growth   = 0.55;

            Mana                 = 280.0;
            Mana_Growth          = 32.0;
            ManaRegen            = 6.972;
            ManaRegen_Growth     = 0.4;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 600;

            MovementSpeed        = 325;
            MovementSpeedPercent = 0.0;
            
            AD                   = 59.0;
            AD_Growth            = 2.96;
            AttackSpeed          = 0.658;
            AttackSpeed_Growth   = 0.0333;
            CritDamage           = 1.75; 
            CritChance           = 0.0;
            Lethality            = 0.0;
            ArmorPen             = 0.0;
            BonusArmorPen        = 0.0;

            AP                   = 0.0;
            AbilityHaste         = 0.0;
            MagicPenFlat         = 0.0;
            MagicPenPerc         = 0.0;
            BonusMagicPenPerc    = 0.0;

            Armor                = 26.0;
            Armor_Growth         = 3.4;
            MR                   = 30;
            MR_Growth            = 0.5;
			PhysDamageReduction  = 0.0;
			MagicDamageReduction = 0.0;
			MostDamageReduction  = 0.0;

            Tenacity             = 0.0;
            PhysicalVamp         = 0.0;
            Omnivamp             = 0.0;
            HealAndShieldPower   = 0.0;
        }
}
}
