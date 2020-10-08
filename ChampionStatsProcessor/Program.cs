using ChampionStatsBuilder;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ChampionStatsProcessor
{
    public class Data
    {
        public string type;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string currDir = AppDomain.CurrentDomain.BaseDirectory;
            string resourcesDir = Path.Combine(currDir, @"..\\..\\..\\Resources");

            JsonTextReader reader = new JsonTextReader(File.OpenText(resourcesDir + "\\champion.json"));

            Object a = JsonConvert.DeserializeObject(File.ReadAllText(resourcesDir + "\\champion.json"));

            
            while(reader.Read())
            {
                Console.WriteLine(reader.Value);
            }

            Console.Write("Done");
            Console.Read();

        }
    }
}
