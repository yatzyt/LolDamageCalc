using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace ChampionStatsBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string currDir = AppDomain.CurrentDomain.BaseDirectory;
        static string resourcesDir = Path.Combine(currDir, @"..\\..\\..\\Resources");

        List<String> champions = new List<string>
            {
                "Aatrox",
                "Ahri",
                "Akali",
                "Alistar",
                "Amumu",
                "Anivia",
                "Annie",
                "Ashe",
                "Aurelion Sol",
                "Azir",
                "Bard",
                "Blitzcrank",
                "Brand",
                "Braum",
                "Caitlyn",
                "Camille",
                "Cassiopeia",
                "Cho'Gath",
                "Corki",
                "Darius",
                "Diana",
                "Dr. Mundo",
                "Draven",
                "Ekko",
                "Elise",
                "Evelynn",
                "Ezreal",
                "Fiddlesticks",
                "Fiora",
                "Fizz",
                "Galio",
                "Gangplank",
                "Garen",
                "Gnar Mini",
                "Gnar Mega",
                "Gragas",
                "Graves",
                "Hecarim",
                "Heimerdinger",
                "Illaoi",
                "Irelia",
                "Ivern",
                "Janna",
                "Jarvan IV",
                "Jax",
                "Jayce",
                "Jhin",
                "Jinx",
                "Kai'Sa",
                "Kalista",
                "Karma",
                "Karthus",
                "Kassadin",
                "Katarina",
                "Kayle",
                "Kayn",
                "Kennen",
                "Kha'Zix",
                "Kindred",
                "Kled",
                "Kog'Maw",
                "Leblanc",
                "Lee Sin",
                "Leona",
                "Lissandra",
                "Lucian",
                "Lulu",
                "Lux",
                "Malphite",
                "Malzahar",
                "Maokai",
                "Master Yi",
                "Miss Fortune",
                "Mordekaiser",
                "Morgana",
                "Nami",
                "Nasus",
                "Nautilus",
                "Nidalee",
                "Nocturne",
                "Nunu & Willump",
                "Olaf",
                "Orianna",
                "Ornn",
                "Pantheon",
                "Poppy",
                "Pyke",
                "Quinn",
                "Rakan",
                "Rammus",
                "Rek'Sai",
                "Renekton",
                "Rengar",
                "Riven",
                "Rumble",
                "Ryze",
                "Sejuani",
                "Shaco",
                "Shen",
                "Shyvana",
                "Sivir",
                "Skarner",
                "Sona",
                "Soraka",
                "Swain",
                "Syndra",
                "Tahm Kench",
                "Taliyah",
                "Talon",
                "Taric",
                "Teemo",
                "Thresh",
                "Tristana",
                "Tryndamere",
                "Twisted Fate",
                "Twitch",
                "Udyr",
                "Urgot",
                "Varus",
                "Vayne",
                "Veigar",
                "Vel'Koz",
                "Vi",
                "Viktor",
                "Vladimir",
                "Volibear",
                "Warwick",
                "Wukong",
                "Xayah",
                "Xerath",
                "Xin Zhao",
                "Yasuo",
                "Yorick",
                "Zac",
                "Zed",
                "Ziggs",
                "Zilean",
                "Zoe",
                "Zyra"
            };

        public MainWindow()
        {
            InitializeComponent();
            
            List<String> currChamps = JsonConvert.DeserializeObject<List<String>>(File.ReadAllText(resourcesDir + "\\champions.json"));
            ChampBox.ItemsSource = currChamps;

            LevelBox.ItemsSource = Enumerable.Range(1, 18);

            EditFlag.IsChecked = true;
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            var currChamp = ChampBox.SelectedItem;

            if (currChamp == null)
            {
                MessageBoxResult errorPopup = MessageBox.Show("Please select a champion.");
            }
            var currLevel = LevelBox.SelectedItem;

            if (currLevel == null)
            {
                MessageBoxResult errorPopup = MessageBox.Show("Please select a champion level.");
            }



            var champFile = resourcesDir + "\\" + currChamp + ".json";

            if (!File.Exists(champFile))
            {
                MessageBoxResult popup = MessageBox.Show("Champion file does not exist.");
                return;
            }

            Champion champion = JsonConvert.DeserializeObject<Champion>(File.ReadAllText(champFile));

            int n = (int)currLevel;

            HealthBox.Text      = champion.CalculateHealth(n).ToString();
            HealthRegenBox.Text = champion.CalculateHealthRegen(n).ToString();
            ManaBox.Text        = champion.CalculateMana(n).ToString();
            ManaRegenBox.Text   = champion.CalculateManaRegen(n).ToString();
            ManaFlag.IsChecked  = Boolean.Parse(champion.Manaless);
            RangeBox.Text       = champion.CalculateRange(n);
            MSBox.Text          = champion.MovementSpeed;
            ADBox.Text          = champion.CalculateAD(n).ToString();
            BASBox.Text         = champion.AttackSpeed;
            AASBox.Text         = String.Format("{0:p}", champion.CalculateBonusAS(n));
            ArBox.Text          = champion.CalculateArmor(n).ToString();
            MRBox.Text          = champion.CalculateMR(n).ToString();

            HealthGBox.Text      = champion.Health_Growth;
            HealthRegenGBox.Text = champion.HealthRegen_Growth;
            ManaGBox.Text        = champion.Mana_Growth;
            ManaRegenGBox.Text   = champion.ManaRegen_Growth;
            ADGBox.Text          = champion.AD_Growth;
            ASGBox.Text          = champion.AS_Growth;
            ArGBox.Text          = champion.Armor_Growth;
            MRGBox.Text          = champion.MR_Growth;

            MessageBoxResult successPopup = MessageBox.Show("Stats loaded.");
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditFlag.IsChecked == true)
            {
                MessageBoxResult errorPopup = MessageBox.Show("Can't save in view only mode.");
                return;
            }

            var currChamp = ChampBox.SelectedItem;
            if (currChamp == null)
            {
                MessageBoxResult errorPopup = MessageBox.Show("Please select a champion.");
                return;
            }
            var currLevel = LevelBox.SelectedItem;
            if (currLevel == null)
            {
                MessageBoxResult errorPopup = MessageBox.Show("Please select a level.");
                return;
            }

            if ((int)currLevel != 1)
            {
                MessageBoxResult errorPopup = MessageBox.Show("You can only save at level 1.");
                return;
            }

            var champFile = resourcesDir + "\\" + currChamp + ".json";

            Boolean fileExists = File.Exists(champFile);

            Champion champion;

            if (fileExists)
                champion = JsonConvert.DeserializeObject<Champion>(File.ReadAllText(champFile));
            else
                champion = new Champion();

            champion.Name = currChamp.ToString();

            champion.Health = HealthBox.Text;
            champion.HealthRegen = HealthRegenBox.Text;
            champion.Mana = ManaBox.Text;
            champion.ManaRegen = ManaRegenBox.Text;
            champion.Manaless = ManaFlag.IsChecked.ToString();
            champion.AutoRange = RangeBox.Text;
            champion.MovementSpeed = MSBox.Text;
            champion.AttackDamage = ADBox.Text;
            champion.AttackSpeed = BASBox.Text;
            champion.Armor = ArBox.Text;
            champion.MagicResist = MRBox.Text;

            champion.Health_Growth = HealthGBox.Text;
            champion.HealthRegen_Growth = HealthRegenGBox.Text;
            champion.Mana_Growth = ManaGBox.Text;
            champion.ManaRegen_Growth = ManaRegenGBox.Text;
            champion.AD_Growth = ADGBox.Text;
            champion.AS_Growth = ASGBox.Text;
            champion.Armor_Growth = ArGBox.Text;
            champion.MR_Growth = MRGBox.Text;

            File.WriteAllText(champFile, JsonConvert.SerializeObject(champion, Formatting.Indented));

            MessageBoxResult successPopup = MessageBox.Show("Stats saved.");
        }
        
        private void ChampionUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (EditFlag.IsChecked == true)
            {
                MessageBoxResult errorPopup = MessageBox.Show("Can't update in view only mode.");
                return;
            }

            // Add new champions to the list with champions.Add(new champion), dont forget to sort

            File.WriteAllText(resourcesDir + "\\champions.json", JsonConvert.SerializeObject(champions, Formatting.Indented));

            MessageBoxResult popup = MessageBox.Show("Champion list updated.");
        }

        private void ChampBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HealthBox.Text =           "";
            HealthRegenBox.Text =      "";
            ManaBox.Text =             "";
            ManaRegenBox.Text =        "";
            RangeBox.Text =            "";
            MSBox.Text =               "";
            ADBox.Text =               "";
            BASBox.Text =              "";
            AASBox.Text =              "";
            ArBox.Text =               "";
            MRBox.Text =               "";
                                       
            HealthGBox.Text =          "";
            HealthRegenGBox.Text =     "";
            ManaGBox.Text =            "";
            ManaRegenGBox.Text =       "";
            ADGBox.Text =              "";
            ASGBox.Text =              "";
            ArGBox.Text =              "";
            MRGBox.Text =              "";

            ManaFlag.IsChecked = false;
        }

        private void LevelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HealthBox.Text = "";
            HealthRegenBox.Text = "";
            ManaBox.Text = "";
            ManaRegenBox.Text = "";
            RangeBox.Text = "";
            MSBox.Text = "";
            ADBox.Text = "";
            BASBox.Text = "";
            AASBox.Text = "";
            ArBox.Text = "";
            MRBox.Text = "";

            HealthGBox.Text = "";
            HealthRegenGBox.Text = "";
            ManaGBox.Text = "";
            ManaRegenGBox.Text = "";
            ADGBox.Text = "";
            ASGBox.Text = "";
            ArGBox.Text = "";
            MRGBox.Text = "";

            ManaFlag.IsChecked = false;
        }

        private void EditFlag_Click(object sender, RoutedEventArgs e)
        {
        }

        private void EditFlag_Checked(object sender, RoutedEventArgs e)
        {
            HealthBox.IsEnabled = false;
            HealthRegenBox.IsEnabled = false;
            ManaBox.IsEnabled = false;
            ManaRegenBox.IsEnabled = false;
            RangeBox.IsEnabled = false;
            MSBox.IsEnabled = false;
            ADBox.IsEnabled = false;
            BASBox.IsEnabled = false;
            AASBox.IsEnabled = false;
            ArBox.IsEnabled = false;
            MRBox.IsEnabled = false;

            HealthGBox.IsEnabled = false;
            HealthRegenGBox.IsEnabled = false;
            ManaGBox.IsEnabled = false;
            ManaRegenGBox.IsEnabled = false;
            ADGBox.IsEnabled = false;
            ASGBox.IsEnabled = false;
            ArGBox.IsEnabled = false;
            MRGBox.IsEnabled = false;

            ManaFlag.IsEnabled = false;
        }

        private void EditFlag_Unchecked(object sender, RoutedEventArgs e)
        {
            HealthBox.IsEnabled = true;
            HealthRegenBox.IsEnabled = true;
            ManaBox.IsEnabled = true;
            ManaRegenBox.IsEnabled = true;
            RangeBox.IsEnabled = true;
            MSBox.IsEnabled = true;
            ADBox.IsEnabled = true;
            BASBox.IsEnabled = true;
            AASBox.IsEnabled = true;
            ArBox.IsEnabled = true;
            MRBox.IsEnabled = true;

            HealthGBox.IsEnabled = true;
            HealthRegenGBox.IsEnabled = true;
            ManaGBox.IsEnabled = true;
            ManaRegenGBox.IsEnabled = true;
            ADGBox.IsEnabled = true;
            ASGBox.IsEnabled = true;
            ArGBox.IsEnabled = true;
            MRGBox.IsEnabled = true;

            ManaFlag.IsEnabled = true;
        }
    }

    public class Champion
    {
        public string Name { get; set; }
        public string Health { get; set; }
        public string HealthRegen { get; set; }
        public string Mana { get; set; }
        public string ManaRegen { get; set; }
        public string Manaless { get; set; }
        public string AutoRange { get; set; }
        public string MovementSpeed { get; set; }
        public string AttackDamage { get; set; }
        public string AttackSpeed { get; set; }
        public string Armor { get; set; }
        public string MagicResist { get; set; }
        public string Health_Growth { get; set; }
        public string HealthRegen_Growth { get; set; }
        public string Mana_Growth { get; set; }
        public string ManaRegen_Growth { get; set; }
        public string AD_Growth { get; set; }
        public string AS_Growth { get; set; }
        public string Armor_Growth { get; set; }
        public string MR_Growth { get; set; }
        public double CalculateHealth(int n)
        {
            return Double.Parse(Health) + Double.Parse(Health_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateHealthRegen(int n)
        {
            return Double.Parse(HealthRegen) + Double.Parse(HealthRegen_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateMana(int n)
        {
            return Double.Parse(Mana) + Double.Parse(Mana_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateManaRegen(int n)
        {
            return Double.Parse(ManaRegen) + Double.Parse(ManaRegen_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateAD(int n)
        {
            return Double.Parse(AttackDamage) + Double.Parse(AD_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateBonusAS(int n)
        {
            if (Name == "Gnar Mini")
                return Double.Parse(AS_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1) + 0.055);
            else
                return Double.Parse(AS_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateArmor(int n)
        {
            return Double.Parse(Armor) + Double.Parse(Armor_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public double CalculateMR(int n)
        {
            return Double.Parse(MagicResist) + Double.Parse(MR_Growth) * (n - 1) * (0.7025 + 0.0175 * (n - 1));
        }
        public string CalculateRange(int n)
        {
            if (Name == "Tristana")
                return (8 * (n - 1) + Double.Parse(AutoRange)).ToString();
            else if (Name == "Gnar Mini")
                return (Double.Parse(AutoRange) + 50 + 5.9 * (n - 1)).ToString();
            else
                return AutoRange;
        }
    }
}
