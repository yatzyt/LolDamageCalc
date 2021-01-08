using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Brand : Champion
    {
        public Brand(string name = "Brand", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 520.0;
            Health_Growth        = 88.0;
            HPRegen              = 5.5;
            HealthRegen_Growth   = 0.55;

            Mana                 = 469.0;
            Mana_Growth          = 21.0;
            ManaRegen            = 10.665;
            ManaRegen_Growth     = 0.6;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 550;

            MovementSpeed        = 340;
            MovementSpeedPercent = 0.0;
            
            AD                   = 57.0;
            AD_Growth            = 3.0;
            AttackSpeed          = 0.625;
            AttackSpeed_Growth   = 0.0136;
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

            Armor                = 22.0;
            Armor_Growth         = 3.5;
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
