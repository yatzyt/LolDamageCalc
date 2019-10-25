using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;

namespace ItemStatsBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Item> items;
        public Dictionary<string, Item> nameToItemMap;
        static string currDir = AppDomain.CurrentDomain.BaseDirectory;
        static string resourcesDir = Path.Combine(currDir, @"..\\..\\..\\Resources");
        //public HashSet<string> possibleStats;

        public MainWindow()
        {
            items = new List<Item>();
            //possibleStats = new HashSet<string>();
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
                item.Id = itemData.Name;
                item.Description = RemoveUnwantedTags((string)itemData.First.SelectToken("description")).Replace("<br>", "\r");
                item.Tags = itemData.First.SelectToken("tags").ToObject<List<string>>();
                item.stats = itemData.First.SelectToken("stats").ToObject<Dictionary<string, string>>();
                items.Add(item);
                /*
                foreach (string statName in item.stats.Keys)
                    possibleStats.Add(statName);
                    */
            }

            List<string> itemNames = items.Select(o => o.Id + " " + o.Name).ToList();
            nameToItemMap = itemNames.Zip(items, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            InitializeComponent();

            itemCombo.ItemsSource = itemNames;
            itemCombo.SelectedIndex = 0;

            Binding desrBinding = new Binding("Description")
            {
                Source = nameToItemMap[(string)itemCombo.SelectedValue],
                UpdateSourceTrigger = UpdateSourceTrigger.Default
            };
            desrText.SetBinding(TextBlock.TextProperty, desrBinding);

            //File.WriteAllText(resourcesDir + "\\possibleStats.json", JsonConvert.SerializeObject(possibleStats, Formatting.Indented));

        }

        internal static string RemoveUnwantedTags(string data)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;

            var document = new HtmlDocument();
            document.LoadHtml(data);

            var acceptableTags = new String[] { "br" };//"strong", "em", "u" };

            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (!acceptableTags.Contains(node.Name) && node.Name != "#text")
                {
                    var childNodes = node.SelectNodes("./*|./text()");

                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            nodes.Enqueue(child);
                            parentNode.InsertBefore(child, node);
                        }
                    }

                    parentNode.RemoveChild(node);

                }
            }

            return document.DocumentNode.InnerHtml;
        }
    }

    public class Item
    {
        public Item()
        { }

        public Item(string n)
        { Name = n; }

        public string Name { get; set; }

        public string Id { get; set; }

        public String Description { get; set; }

        public List<string> Tags { get; set; }

        public Dictionary<string, string> stats { get; set; }
    }
}
