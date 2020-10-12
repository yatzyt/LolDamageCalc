using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Alistar : Champion
    {
        public Alistar(string name = "Alistar", int level = 1)
        {
            Name = name;
            Level = level;

            HP = 600.0;
            Health_Growth = 106.0;
            HPRegen = 8.5;
            HealthRegen_Growth = 0.85;

            Mana = 350.0;
            Mana_Growth = 40.0;
            ManaRegen = 8.5;
            ManaRegen_Growth = 0.8;
            Manaless = false;
            Energy = false;

            AutoRange = 125.0;

            MovementSpeed = 330.0;
            MovementSpeedPercent = 0.0;

            AD = 62.0;
            AD_Growth = 3.75;
            AttackSpeed = 0.625;
            AttackSpeed_Growth = 0.02125;
            CritDamage = 1.75;
            CritChance = 0.0;
            Lethality = 0.0;
            ArmorPen = 0.0;
            BonusArmorPen = 0.0;

            AP = 0.0;
            AbilityHaste = 0.0;
            MagicPenFlat = 0.0;
            MagicPenPerc = 0.0;
            BonusMagicPenPerc = 0.0;

            Armor = 44.0;
            Armor_Growth = 3.5;
            MR = 32.1;
            MR_Growth = 1.25;
            PhysDamageReduction = 0.0;
            MagicDamageReduction = 0.0;
            MostDamageReduction = 0.0;

            Tenacity = 0.0;
            PhysicalVamp = 0.0;
            Omnivamp = 0.0;
            HealAndShieldPower = 0.0;
        }

        /// <summary>
        /// Triumphant Roar
        /// <para>Heals Alistar for 17 + 8 * Level hp, and other allied champions for double the amount.</para>
        /// </summary>
        /// <returns>The amount it heals Alistar for as a double.</returns>
        public double Passive()
        {
            return Level * 8 + 17.0;
        }

        /// <summary>
        /// Pulverize
        /// <para>60/105/150/195/240 + 50% AP</para>
        /// </summary>
        /// <param name="rank">Rank of ability as an int</param>
        /// <returns>Damage dealt as a double</returns>
        public double Q(int rank) //TODO: determine how to check what type of damage an ability does
        {
            double Q_base = 60 + ((rank - 1) * 45);
            double Q_scaling = 0.5;
            double Q_damage = Q_base + (Q_scaling * CalculateAP());
            return Q_damage;
        }

        /// <summary>
        /// Headbutt
        /// <para>55/110/165/220/275 + 70% AP</para>
        /// </summary>
        /// <param name="rank">Rank of ability as an int</param>
        /// <returns>Damage dealt as a double</returns>
        public double W(int rank)
        {
            double W_base = 55 + ((rank - 1) * 55);
            double W_scaling = .7;
            double W_damage = W_base + W_scaling * CalculateAP();
            return W_damage;
        }

        /// <summary>
        /// Trample
        /// <para>E1: 8/11/14/17/20 + 4% AP, every 0.5 seconds for 5 seconds</para>
        /// <para>E2: 20 + 15 * level</para>
        /// </summary>
        /// <param name="rank">Rank of ability as an int</param>
        /// <returns>Damage dealt as a list of doubles, in the order of E1 dps, E1 total, E2</returns>
        public List<double> E(int rank)
        {
            double E1_base = 8 + ((rank - 1) * 3);
            double E1_scaling = 0.04;

            double E1_damage_tick = E1_base
                + E1_scaling * CalculateAP();

            double E1_damage_total = E1_damage_tick * 10;

            double E2_damage = 20 + 15 * Level;

            return new List<double>(){ E1_damage_tick, E1_damage_total, E2_damage};
        }

        /// <summary>
        /// Unbreakable Will
        /// <para>55/65/75%</para>
        /// </summary>
        /// <param name="rank"></param>
        public void R(int rank)
        {
            MostDamageReduction = .55 + ((rank - 1) * .1);
        }
    }
}
