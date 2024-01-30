using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp13
{
    internal class Citrus : Fruit
    {
        double vitaminC;
        public double VitaminC { get { return vitaminC; } set { vitaminC = value; } }
        public Citrus(string name, string color, double vitaminC) : base(name, color)
        {
            this.vitaminC = vitaminC; 
        }

        public override Citrus Input()
        {
            Console.Write("Input fruit name: ");
            Name = Console.ReadLine();
            Console.Write("Input fruit color: ");
            Color = Console.ReadLine();
            Console.Write("Input fruit amount of vitamin C: ");
            vitaminC = double.Parse(Console.ReadLine());
            return this;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return base.ToString() + $", Vitamin C: {this.vitaminC}";
        }
    }
}
