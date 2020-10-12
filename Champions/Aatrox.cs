﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Aatrox : Champion
    {
        public Aatrox(string name = "Aatrox", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 580.0;
            Health_Growth        = 90.0;
            HPRegen              = 3.0;
            HealthRegen_Growth   = 1.0;

            Mana                 = 0;
            Mana_Growth          = 0;
            ManaRegen            = 0;
            ManaRegen_Growth     = 0;
            Manaless             = true;
            Energy               = false;

            AutoRange            = 175.0;

            MovementSpeed        = 345.0;
            MovementSpeedPercent = 0;
            
            AD                   = 60.0;
            AD_Growth            = 5.0;
            AttackSpeed          = 0.651;
            AttackSpeed_Growth   = 0.025;
            CritDamage           = 1.75;         // Season 11 = 1.75, Season 10 = 2
            CritChance           = 0.0;
            Lethality            = 0.0;
            ArmorPen             = 0.0;
            BonusArmorPen        = 0.0;

            AP                   = 0.0;
            AbilityHaste         = 0.0;
            MagicPenFlat         = 0.0;
            MagicPenPerc         = 0.0;
            BonusMagicPenPerc    = 0;

            Armor                = 38.0;
            Armor_Growth         = 3.25;
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

        /// <summary><para>Deathbringer Stance</para>
        /// <para>Next basic attack deals 5%-12% of the targer's maximum health based on their level as bonus physical damage.</para>
        /// <para>Heals Aatrox for 100% of the bonus damage dealt.</para></summary>
        /// 
        /// <param name="enemy_Level">The level of the enemy champion.</param>
        /// <param name="enemy_maxHP">The maximum HP of the enemy champion.</param>
        /// 
        /// <returns>Returns a string containting the amount of damage dealt.</returns>
        ///
        public double Passive(double enemy_maxHP)
        {
            double percent_health = (4.588 + (0.412 * Level)) / 100;
            double damage_dealt = enemy_maxHP * percent_health;
            return damage_dealt;
        }

        /// <summary><para>The Darkin Blade</para>
        /// <para>Sweetspot = 50% bonus damage</para>
        /// <para>Q2 = 1.25*Q1, Q3 = 1.5*Q1</para>
        /// <para>Q1: 10/30/50/70/90 + 60/65/70/75/80 % AD</para>
        /// <para>Q2: 12.5/37.5/62.5/87.5/112.5 + 75/81.25/93.75/100 % AD</para>
        /// <para>Q3: 15/45/75/105/135 + 90/97.5/105/112.5/120 % AD</para></summary>
        ///
        /// <param name="rank">The rank of the ability.</param>
        /// 
        /// <returns>Returns a list of doubles in the order of Q1-normal, Q1-sweetspot, Q2-normal, Q2-sweetspot, Q3-normal, Q3-sweetspot.</returns>
        ///
        public List<double> Q(int rank)
        {
            double Q1_base = 10 + ((rank - 1) * 20);
            double Q1_scaling = (60.0 + ((rank - 1) * 5)) / 100;

            double Q2_base = Q1_base * 1.25;
            double Q2_scaling = Q1_scaling * 1.25;

            double Q3_base = Q1_base * 1.5;
            double Q3_scaling = Q1_scaling * 1.5;

            double Q1_damage_normal = Q1_base 
                + Q1_scaling * CalculateAD();

            double Q2_damage_normal = Q2_base 
                + Q2_scaling * CalculateAD();

            double Q3_damage_normal = Q3_base 
                + Q3_scaling * CalculateAD();

            double Q1_damage_sweet = Q1_damage_normal * 1.5;
            double Q2_damage_sweet = Q2_damage_normal * 1.5;
            double Q3_damage_sweet = Q3_damage_normal * 1.5;

            return new List<double>()
            { Q1_damage_normal, Q1_damage_sweet, Q2_damage_normal, Q2_damage_sweet, Q3_damage_normal, Q3_damage_sweet };
        }

        /// <summary>
        /// <para>Infernal Chains</para>
        /// <para>W: 30/40/50/60/70 + 40% AD</para>
        /// </summary>
        /// <param name="rank">The rank of the ability as an int.</param>
        /// <returns>The damage dealt as a double.</returns>
        public double W(int rank)
        {
            double W_base = 30 + ((rank - 1) * 10);
            double W_scaling = .4;

            double W_damage = W_base 
                + W_scaling * CalculateAD();

            return W_damage;
        }
        
        /// <summary>
        /// World Ender
        /// <para>Gains 20/30/40 % AD</para>
        /// </summary>
        /// <param name="rank">The rank of the ability as an int.</param>
        /// <returns>The amount of bonus AD Aatrox gains as a double.</returns>
        public double R(int rank)
        {
            double R_bAD_scaling = .2 + ((rank - 1) * .1);
            double R_bAD = CalculateAD();
            return R_bAD;
        }

    }
}
