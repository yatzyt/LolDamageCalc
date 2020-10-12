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

        /// <summary>
        /// Bandage Toss
        /// <para>80/130/180/230/280 + 70% AP</para>
        /// </summary>
        /// <param name="rank">Rank of spell as an int.</param>
        /// <returns>Damage dealt as a double.</returns>
        public double Q(int rank)
        {
            double Q_base = 80.0 + ((rank - 1) * 50);
            double Q_scaling = .7;

            double Q_damage = Q_base
                + Q_scaling * CalculateAP();

            return Q_damage;
        }

        /// <summary>
        /// Despair
        /// <para>5/7.5/10/12.5/15 + 0.5/0.625/0.75/0.875/1% (+ 0.5% per 100AP) of target's maximum health</para>
        /// </summary>
        /// <param name="rank">Rank of spell as an int.</param>
        /// <returns>Damage dealt as a double.</returns>
        public double W(int rank, double enemy_health)
        {
            double W_base = 5.0 + 
        }
}
}
