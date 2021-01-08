using System;
using System.Collections.Generic;
using static System.Math;

namespace Champions
{
    public class Annie : Champion
    {
        public Annie(string name = "Annie", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 524.0;
            Health_Growth        = 88.0;
            HPRegen              = 5.5;
            HealthRegen_Growth   = 0.55;

            Mana                 = 418.0;
            Mana_Growth          = 25.0;
            ManaRegen            = 8.0;
            ManaRegen_Growth     = 0.8;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 625.0;

            MovementSpeed        = 335.0;
            MovementSpeedPercent = 0.0;
            
            AD                   = 50.0;
            AD_Growth            = 2.63;
            AttackSpeed          = 0.579;
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

        /// <summary>
        /// Disintegrate
        /// <para>80/115/150/185/220 + 80% AP</para>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public double Q(int rank)
        {
            double Q_base = 80.0 + ((rank - 1) * 35);
            double Q_scaling = 0.8;

            double Q_damage = Q_base
                + Q_scaling * CalculateAP();

            return Q_damage;
        }

        /// <summary>
        /// Incinerate 
        /// <para>70/115/160/205/250 + 85% AP</para>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public double W(int rank)
        {
            double W_base = 70.0 + ((rank - 1) * 45);
            double W_scaling = 0.85;

            double W_damage = W_base
                + W_scaling * CalculateAP();

            return W_damage;
        }

        /// <summary>
        /// Molten Shield
        /// <para>Damage: 20/30/40/50/60 + 20% AP</para>
        /// <para>Damage Reduction: 13/17/21/25/29%</para>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public double E(int rank)
        {
            MostDamageReduction = 0.13 + ((rank - 1) * 0.04);

            double E_base = 20.0 + ((rank - 1) * 10);
            double E_scaling = .2;

            double E_damage = E_base
                + E_scaling * CalculateAP();

            return E_damage;
        }

        /// <summary>
        /// Summon: Tibbers
        /// <para>Initial: 150/275/400 + 75% AP</para>
        /// <para>Aura: 5/7.5/10 + 3% AP</para>
        /// <para>Bear Slap: 50/75/100 + 15% AP</para>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns><para>Returns two lists, the first list contains the damage values as doubles in the order of: initial damage, aura damage, bear slap damage. </para>
        /// <para>The second list contains the values of Tibber's attack speed in the order of: normal, enraged #1, enraged #2 ... enraged #5.</para></returns>
        public Tuple<List<double>, List<double>> R(int rank)
        {
            double R_base_initial = 150.0 + ((rank - 1) * 125);
            double R_scaling_initial = 0.75;

            double R_damage_initial = R_base_initial
                + R_scaling_initial * CalculateAP();

            double R_base_aura = 5.0 + ((rank - 1) * 2.5);
            double R_scaling_aura = 0.03;

            double R_damage_aura = R_base_aura
                + R_scaling_aura * CalculateAP();

            double R_base_slap = 50.0 + ((rank - 1) * 25);
            double R_scaling_slap = 0.15;

            double R_damage_slap = R_base_slap
                + R_scaling_slap * CalculateAP();
            
            List<double> R_damages = new List<double>() { R_damage_initial, R_damage_aura, R_damage_slap };

            List<double> R_attackspeeds = new List<double>();

            double R_attackspeed_normal = 0.625;
            R_attackspeeds.Add(R_attackspeed_normal);

            for (int attacks_consumed = 1; attacks_consumed <= 5; attacks_consumed++)
            {
                double R_attackspeed_enrage_next = 1.736 * (1 - (11.505 * (attacks_consumed - 1) + 0.3 * (Pow(attacks_consumed - 2, 3) - (attacks_consumed - 2)) / 6
                    + 1.7 * (attacks_consumed - 2) * (attacks_consumed - 1) / 2) / 100);
                R_attackspeeds.Add(R_attackspeed_enrage_next);
            }

            return new Tuple<List<double>, List<double>>(R_damages, R_attackspeeds);
        }
}
}
