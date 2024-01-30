using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Fruit : IComparable<Fruit>
    {
        string name;
        string color;
        public string Name { get { return name; } set { name = value; } }
        public string Color { get { return color; } set { color = value; } }

        public Fruit(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public virtual Fruit Input()
        {
            Console.Write("Input fruit name: ");
            name = Console.ReadLine();
            Console.Write("Input fruit color: ");
            color = Console.ReadLine();
            return this;
        }

        public virtual void Print()
        {
            Console.WriteLine(ToString());
        }

        public static List<Fruit> Input(string path)
        {
            List<Fruit> fruits = new();

            string pattern = @"Name: (\w+), Color: (\w+)(, Vitamin C: (\d+(\.\d+)?))?";
            foreach (string line in File.ReadAllLines(path).ToList())
            {
                Fruit fruit = new(null, null);
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    fruit.Name = match.Groups[1].Value;
                    fruit.Color = match.Groups[2].Value;

                    if (match.Groups[4].Success)
                    {
                        double vitaminC;
                        if (double.TryParse(match.Groups[4].Value, out vitaminC))
                        {
                            fruit = new Citrus(fruit.Name, fruit.Color, vitaminC);
                        }
                    }
                    fruits.Add(fruit);
                }
            }
            return fruits;
        }

        public static void Print(List<Fruit> fruits, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Fruit f in fruits)
                {
                    if (f is Citrus)
                    {
                        Citrus c = (Citrus)f;
                        sw.WriteLine(c.ToString());
                    }
                    else
                    {
                        sw.WriteLine(f.ToString());
                    }
                }
            }
            Console.WriteLine($"Check out your document '{path}'.");
        }

        public override string ToString()
        {
            return $"Name: {this.name}, Color: {this.color}";
        }

        int IComparable<Fruit>.CompareTo(Fruit? other)
        {
            //return int.Parse(this.Tool).CompareTo(int.Parse(other.Tool)) * -1;
            return this.Name.CompareTo(other.Name);
        }
    }
}
