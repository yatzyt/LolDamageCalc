using System;
using System.Collections.Generic;
using System.Text;

namespace Champions
{
    public class Anivia : Champion
    {
        public Anivia(string name = "Anivia", int level = 1)
        {
            Name                 = name;
            Level                = level;

            HP                   = 480.0;
            Health_Growth        = 82.0;
            HPRegen              = 5.5;
            HealthRegen_Growth   = 0.55;

            Mana                 = 495.0;
            Mana_Growth          = 25.0;
            ManaRegen            = 8.0;
            ManaRegen_Growth     = 0.8;
            Manaless             = false;
			Energy               = false;

            AutoRange            = 600.0;

            MovementSpeed        = 325.0;
            MovementSpeedPercent = 0.0;
            
            AD                   = 51.376;
            AD_Growth            = 3.2;
            AttackSpeed          = 0.625;
            AttackSpeed_Growth   = 0.0168;
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

            Armor                = 21.22;
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
        /// Flash Frost
        /// <para>60/85/110/135/160 + 45% AP</para>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns>Damage of one hit as a double</returns>
        public double Q(int rank)
        {
            double Q_base = 60.0 + ((rank - 1) * 25);
            double Q_scaling = 0.45;

            double Q_damage = Q_base
                + Q_scaling * CalculateAP();

            return Q_damage;
        }

        /// <summary>
        /// Frostbite
        /// <para>50/75/100/125/150 + 50% AP</para>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns>Damage of normal E as a double</returns>
        public double E(int rank)
        {
            double E_base = 50.0 + ((rank - 1) * 25);
            double E_scaling = 0.5;

            double E_damage = E_base
                + E_scaling * CalculateAP();

            return E_damage;
        }

        /// <summary>
        /// Glacial Storm
        /// <para>40/60/80 + 12.5% AP</para>
        /// <para>Fully charged: 120/180/240 + 37.5% AP</para>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns>Damages as a list of doubles in the order of damage per second, empowered damage per second</returns>
        public List<double> R(int rank)
        {
            double R_base = 40.0 + ((rank - 1) * 20);
            double R_scaling = 0.125;

            double R_damage = R_base
                + R_scaling * CalculateAP();

            double R_damage_empowered = R_damage * 3.0;

            return new List<double>() { R_damage, R_damage_empowered };
        }
}
}
