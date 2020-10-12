using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Amumu : Champion
    {
        public Amumu(string name = "Amumu", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 613.12;
            Health_Growth        = 84.0;
            HPRegen              = 9.0;
            HealthRegen_Growth   = 0.85;

            Mana                 = 287.2;
            Mana_Growth          = 40.0;
            ManaRegen            = 7.382;
            ManaRegen_Growth     = 0.525;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 125.0;

            MovementSpeed        = 335.0;
            MovementSpeedPercent = 0.0;
            
            AD                   = 53.38;
            AD_Growth            = 3.8;
            AttackSpeed          = 0.736;
            AttackSpeed_Growth   = 0.0218;
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

            Armor                = 33.0;
            Armor_Growth         = 3.8;
            MR                   = 32.1;
            MR_Growth            = 1.25;
			PhysDamageReduction  = 0.0;
			MagicDamageReduction = 0.0;
			MostDamageReduction  = 0.0;

            Tenacity             = 0.0;
            PhysicalVamp         = 0.0;
            Omnivamp             = 0.0;
            HealAndShieldPower   = 0.0;
        }

        /// <summary>
        /// Cursed Touch
        /// <para>Cursed targets receive 10% bonus true damage from all incoming pre-mitigation magic damage.</para>
        /// </summary>
        /// <returns></returns>
        public double Passive()
        {
            return 0.1;
        }

        public double Q(int rank)
        {
            return 0;
        }
}
}
