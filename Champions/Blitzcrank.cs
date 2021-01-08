﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Blitzcrank : Champion
    {
        public Blitzcrank(string name = "Blitzcrank", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 583.0;
            Health_Growth        = 95.0;
            HPRegen              = 8.5;
            HealthRegen_Growth   = 0.75;

            Mana                 = 267.2;
            Mana_Growth          = 40.0;
            ManaRegen            = 8.5;
            ManaRegen_Growth     = 0.8;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 125;

            MovementSpeed        = 325;
            MovementSpeedPercent = 0.0;
            
            AD                   = 62.0;
            AD_Growth            = 3.5;
            AttackSpeed          = 0.625;
            AttackSpeed_Growth   = 0.0113;
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

            Armor                = 37.0;
            Armor_Growth         = 3.5;
            MR                   = 32;
            MR_Growth            = 1.25;
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
