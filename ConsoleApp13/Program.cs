namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fruit> fruits =
            [
                new("Apple", "Red"),
                new("Apple", "Green"),
                new Citrus("Lemon", "Yellow", 5.2),
                new Citrus("Orange", "Orange", 7.5),
                new("Banana", "Yellow"),
                new Citrus("Pomelo", "Yellow", 3.0),
                new Citrus("Clementine", "Yellow", 6.6)
            ];

            foreach (var fruit in fruits.Where(f => f.Color == "Yellow"))
            {
                Console.WriteLine(fruit.ToString());
            }
            Console.WriteLine("---------------");
            fruits.Sort();
            foreach (Fruit fruit in fruits)
            {
                fruit.Print();
            }

            fruits.Clear();
            fruits = Fruit.Input("Fruits.txt");

            Console.WriteLine("---------------");
            foreach (Fruit fruit in fruits)
            {
                fruit.Print();
            }
            Console.WriteLine("---------------");
            Fruit.Print(fruits, "Fruits.txt");
            Console.WriteLine("---------------");


            Console.Write("Input total amount of fruits to add: ");
            int fruitsToAdd = int.Parse(Console.ReadLine());
            for (int i = 0; i < fruitsToAdd; i++)
            {
                Console.Write("Do you want to add citrus or just a fruit (0/1)?: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Citrus? c = new(string.Empty, string.Empty, 0);
                        c = c.Input();
                        fruits.Add(c);
                        break;
                    case 1:
                        Fruit? f = new(string.Empty, string.Empty);
                        f = f.Input();
                        fruits.Add(f);
                        break;
                    default:
                        Console.WriteLine("Something went wrong :(");
                        break;

                }
            }

            Console.ReadKey();
        }
    }
}
