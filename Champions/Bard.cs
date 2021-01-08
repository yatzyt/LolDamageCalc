using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Bard : Champion
    {
        public Bard(string name = "Bard", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 560.0;
            Health_Growth        = 89.0;
            HPRegen              = 5.5;
            HealthRegen_Growth   = 0.55;

            Mana                 = 350.0;
            Mana_Growth          = 50.0;
            ManaRegen            = 6.0;
            ManaRegen_Growth     = 0.45;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 500;

            MovementSpeed        = 330;
            MovementSpeedPercent = 0.0;
            
            AD                   = 52.0;
            AD_Growth            = 3.0;
            AttackSpeed          = 0.625;
            AttackSpeed_Growth   = 0.02;
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

            Armor                = 34.0;
            Armor_Growth         = 4.0;
            MR                   = 30.0;
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
