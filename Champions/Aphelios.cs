using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Aphelios : Champion
    {
        public Aphelios(string name = "Aphelios", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 530.0;
            Health_Growth        = 88.0;
            HPRegen              = 3.25;
            HealthRegen_Growth   = 0.55;

            Mana                 = 348.0;
            Mana_Growth          = 42.0;
            ManaRegen            = 6.5;
            ManaRegen_Growth     = 2.4;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 550;

            MovementSpeed        = 325;
            MovementSpeedPercent = 0.0;
            
            AD                   = 57;
            AD_Growth            = 2.4;
            AttackSpeed          = 0.64;
            AttackSpeed_Growth   = 0.021;
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

            Armor                = 28.0;
            Armor_Growth         = 3.0;
            MR                   = 26.0;
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
