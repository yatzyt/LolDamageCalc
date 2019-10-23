using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ItemStatsBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Item> items;
        static string currDir = AppDomain.CurrentDomain.BaseDirectory;
        static string resourcesDir = Path.Combine(currDir, @"..\\..\\..\\Resources");

        public MainWindow()
        {
            InitializeComponent();
            items = new List<Item>();
            var itemDir = resourcesDir + "\\item.json";
            if (!File.Exists(itemDir))
            {
                MessageBoxResult popup = MessageBox.Show("Items data does not exist.");
                return;
            }

            JToken token = JObject.Parse(File.ReadAllText(itemDir));
            JToken data = token.SelectToken("data");

            foreach (JProperty itemData in data)
            {
                Item item = new Item((string)itemData.First.SelectToken("name"));
                item.id = itemData.Name;
                item.description = (string)itemData.First.SelectToken("description");
                item.tags = itemData.First.SelectToken("tags").ToObject<List<string>>();
                item.stats = itemData.First.SelectToken("stats").ToObject<Dictionary<string, string>>();
                items.Add(item);                
            }

            List<string> itemNames = items.Select(o => o.name).ToList();

            itemCombo.ItemsSource = itemNames;

        }
    }

    public class Item
    {
        public Item()
        { }

        public Item(string n)
        { name = n; }

        public string name { get; set; }

        public string id { get; set; }

        public string description { get; set; }

        public List<string> tags { get; set; }

        public Dictionary<string, string> stats { get; set; }
    }
}
