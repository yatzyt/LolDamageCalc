﻿using System;
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

            HP                   = 613.0;
            Health_Growth        = 80.0;
            HPRegen              = 9.0;
            HealthRegen_Growth   = 0.85;

            Mana                 = 285.0;
            Mana_Growth          = 40.0;
            ManaRegen            = 7.382;
            ManaRegen_Growth     = 0.525;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 125.0;

            MovementSpeed        = 335.0;
            MovementSpeedPercent = 0.0;
            
            AD                   = 53.0;
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

            Armor                = 30.0;
            Armor_Growth         = 3.8;
            MR                   = 32.0;
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
        /// <para>5/7.5/10/12.5/15 + 0.5/0.625/0.75/0.875/1% (+ 0.5% per 100AP) of target's maximum health, per 0.5 seconds.</para>
        /// </summary>
        /// <param name="rank">Rank of spell as an int.</param>
        /// <returns>Damage dealt as a double.</returns>
        public double W(int rank, double enemy_health)
        {
            double W_base = 5.0 + ((rank - 1) * 2.5);
            double W_scaling = 0.005;
            double W_percentHP_scaling = 0.005 + ((rank - 1) * 0.00125) + W_scaling * CalculateAP();

            double W_damage = W_base 
                + enemy_health * W_percentHP_scaling;

            return W_damage;
        }

        /// <summary>
        /// Tantrum
        /// <para>Physical damage reduction: 2/4/6/8/10 + 3% bonus armor + 3% bonus mr</para>
        /// <para>Damage: 75/100/125/150/175 + 50% AP</para>
        /// </summary>
        /// <param name="rank">Rank of spell as an int.</param>
        /// <returns>Damage dealt as a double.</returns>
        public double E(int rank)
        {
            double E_base_reduction = 2 + ((rank - 1) * 2);
            double E_scaling_reduction = 0.03;
            double E_reduction = E_base_reduction
                + E_scaling_reduction * CalculateBonusArmor()
                + E_scaling_reduction * CalculateBonusMR();

            FlatPhysDamageReduction = E_reduction;

            double E_base = 75.0 + ((rank - 1) * 25);
            double E_scaling = 0.5;

            double E_damage = E_base
                + E_scaling * CalculateAP();

            return E_damage;
        }

        /// <summary>
        /// Curse of the Sad Mummy
        /// <para>150/250/350 + 80% AP</para>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public double R(int rank)
        {
            double R_base = 150.0 + ((rank - 1) * 100);
            double R_scaling = .8;

            double R_damage = R_base
                + R_scaling * CalculateAP();

            return R_damage;
        }
}
}
