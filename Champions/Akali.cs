﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    class Akali : Champion
    {
        /// <summary>
        /// Assassin's Mark
        /// <para>39/42/45/48/51/54/57/60/69/78/87/96/105/120/135/150/165/180 + 60% bAD + 50% AP</para>
        /// </summary>
        /// <returns></returns>
        public double Passive()
        {
            double P_base = 0;
            if (Level <= 8)
                P_base = 39 + ((Level - 1) * 3);
            else if (Level > 8 && Level <= 13)
                P_base = (Level * 9) - 12;
            else
                P_base = (Level * 15) - 90;

            double P_bAD_scaling = .6;
            double P_AP_scaling = .5;

            double P_damage = P_base + P_bAD_scaling * CalculateBonusAD(Level) + P_AP_scaling * CalculateAP(Level);
            return P_damage;
        }

        /// <summary>
        /// Five Point Strike
        /// <para>30/55/80/105/130 + 65% AD + 60% AP</para>
        /// </summary>
        /// <param name="rank">The rank of the spell as an int.</param>
        /// <returns>Damage of spell as a double</returns>
        public double Q(int rank)
        {
            double Q_base = 30 + ((rank - 1) * 25);
            double Q_AD_scaling = .65;
            double Q_AP_scaling = .6;

            double Q_damage = Q_base + Q_AD_scaling * CalculateAD(Level) + Q_AP_scaling * CalculateAP(Level);
            return Q_damage;
        }

        /// <summary>
        /// Shuriken Flip
        /// <para>50/85/120/155/190 + 35% AD + 50% AP</para>
        /// </summary>
        /// <param name="rank">The rank of the spell as an int.</param>
        /// <returns>The damage of one part of the spell as a double</returns>
        public double E(int rank)
        {
            double E_base = 50 + ((rank - 1) * 35);
            double E_AD_scaling = .35;
            double E_AP_scaling = .5;

            double E_damage = E_base + E_AD_scaling * CalculateAD(Level) + E_AP_scaling * CalculateAP(Level);
            return E_damage;
        }

        /// <summary>
        /// Perfect Execution
        /// <para>R1</para>
        /// <para>125/225/325 + 50% bAD</para>
        /// <para>R2</para>
        /// <para>75/145/215 + 30% AP, increased by 2.86% per 1% missing hp, capped at 70% missing hp.</para>
        /// </summary>
        /// <param name="rank">The rank of the spell.</param>
        /// <returns>A list containing the damage as doubles in the order of R1, R2.</returns>
        public List<double> R(int rank, double missing_hp_perc)
        {
            if (missing_hp_perc > .7)
                missing_hp_perc = .7;

            List<double> R_damages = new List<double>();

            double R1_base = 125 + ((rank - 1) * 100);
            double R1_scaling = .5;
            double R1_damage = R1_base + R1_scaling * CalculateBonusAD(Level);
            R_damages.Add(R1_damage);

            double R2_base = 75 + ((rank - 1) * 70);
            double R2_scaling = .3;
            double R2_amp = 1 + (.0286 * missing_hp_perc * 100);
            double R2_damage = R2_amp * (R2_base + R2_scaling * CalculateAP(Level));
            R_damages.Add(R2_damage);

            return R_damages;
        }
    }
}
