using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Ahri : Champion
    {
        public Ahri(string name = "Ahri", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 526.0;
            Health_Growth        = 92.0;
            HPRegen              = 5.5;
            HealthRegen_Growth   = 0.6;

            Mana                 = 418.0;
            Mana_Growth          = 25.0;
            ManaRegen            = 8.0;
            ManaRegen_Growth     = 0.8;
            Manaless             = false;
            Energy               = false;

            AutoRange            = 550.0;

            MovementSpeed        = 330.0;
            MovementSpeedPercent = 0.0;

            AD                   = 53.04;
            AD_Growth            = 3.0;
            AttackSpeed          = 0.668;
            AttackSpeed_Growth   = 0.02;
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

            Armor                = 20.88;
            Armor_Growth         = 3.5;
            MR                   = 30;
            MR_Growth            = 0.5;

            PhysDamageReduction  = 0.0;
            MagicDamageReduction = 0.0;
            MostDamageReduction  = 0.0;

            Tenacity             = 0;
            PhysicalVamp         = 0;
            Omnivamp             = 0;
            HealAndShieldPower   = 0;
        }

        /// <summary>
        /// Orb of Deception
        /// <para>Per pass</para>
        /// <para>40/65/90/115/140 + 35% AP</para>
        /// </summary>
        /// <param name="rank">Rank of the spell as an int.</param>
        /// <returns>Damage of one pass as a double.</returns>
        public double Q(int rank)
        {
            double Q_base = 40 + ((rank - 1) * 25);
            double Q_scaling = .35;
            double Q_damage = Q_base + Q_scaling * CalculateAP();
            return 0;
        }

        /// <summary>
        /// Fox-Fire
        /// <para>First orb</para>
        /// <para>40/65/90/115/140 + 30% AP</para>
        /// <para>Subsequent orbs</para>
        /// <para>12/19.5/27/34.5/42 + 9% AP</para>
        /// </summary>
        /// <param name="rank">Rank of the spell as an int.</param>
        /// <returns>A list of doubles representing the damage dealt in the order of 1st orb, 1+2 orbs, all orbs.</returns>
        public List<double> W(int rank)
        {
            List<double> W_damages = new List<double>();
            double W_base = 40 + ((rank - 1) * 25);
            double W_scaling = .3;
            double W_followup_penalty = 0.3;
            double W_followup_base = W_base * W_followup_penalty;
            double W_followup_scaling = W_scaling * W_followup_penalty;

            double W_damage = W_base + W_scaling * CalculateAP();
            double W_followup_damage = W_followup_base + W_followup_scaling * CalculateAP();

            W_damages.Add(W_damage);
            W_damages.Add(W_damage + W_followup_damage);
            W_damages.Add(W_damage + W_followup_damage * 2);

            return W_damages;
        }

        /// <summary>
        /// Charm
        /// <para>60//90/120/150/180 + 40% AP</para>
        /// </summary>
        /// <param name="rank">Rank of the spell as an int.</param>
        /// <returns>A list of doubles in the order of: damage dealt, damage amplification.</returns>
        public List<double> E(int rank)
        {
            List<double> E_values = new List<double>();

            double E_base = 60 + ((rank - 1) * 30);
            double E_scaling = .4;

            double E_damage = E_base + E_scaling * CalculateAP();
            double E_amp = .2;

            E_values.Add(E_damage);
            E_values.Add(E_amp);

            return E_values;
        }

        /// <summary>
        /// Spirit Rush
        /// <para>60/90/120 + 35% AP</para>
        /// </summary>
        /// <param name="rank">Rank of the spell as an int.</param>
        /// <returns>Single target damage of one dash as a double.</returns>
        public double R(int rank)
        {
            double R_base = 60 + ((rank - 1) + 30);
            double R_scaling = .35;

            double R_damage = R_base + R_scaling * CalculateAP();

            return R_damage;
        }
    }
}
