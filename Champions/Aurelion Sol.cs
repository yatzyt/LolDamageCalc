using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Aurelion_Sol : Champion
    {
        public Aurelion_Sol (string name = "Aurelion Sol", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 575.0;
            Health_Growth        = 92.0;
            HPRegen              = 350.0;
            HealthRegen_Growth   = 50.0;

            Mana                 = 350.0;
            Mana_Growth          = 50.0;
            ManaRegen            = 6.0;
            ManaRegen_Growth     = 0.8;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 550;

            MovementSpeed        = 325;
            MovementSpeedPercent = 0.0;
            
            AD                   = 57.0;
            AD_Growth            = 3.2;
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

            Armor                = 19.0;
            Armor_Growth         = 3.6;
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
