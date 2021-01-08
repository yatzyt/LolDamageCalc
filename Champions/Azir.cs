using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Azir : Champion
    {
        public Azir(string name = "Azir", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 552.0;
            Health_Growth        = 92.0;
            HPRegen              = 7.0;
            HealthRegen_Growth   = 0.75;

            Mana                 = 480.0;
            Mana_Growth          = 21.0;
            ManaRegen            = 8.0;
            ManaRegen_Growth     = 0.8;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 525;

            MovementSpeed        = 335;
            MovementSpeedPercent = 0.0;
            
            AD                   = 52.0;
            AD_Growth            = 2.8;
            AttackSpeed          = 0.625;
            AttackSpeed_Growth   = 0.03;
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
            Armor_Growth         = 3.0;
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
