namespace delegates
{
    enum Operation
    {
        Plus, Minus, Mult, Div
    }

    class Calculator
    {
        Func<double,double,double>? func;
        public void setOperation(Operation op)
        {
            switch (op)
            {
                case Operation.Plus:
                    func = (x, y) => x + y;
                    break;
                case Operation.Minus:
                    func = (x, y) => x - y;
                    break;
                case Operation.Div:
                    func = (x, y) => x / y;
                    break;
                case Operation.Mult:
                    func = (x, y) => x * y;
                    break;
            }
        }
        public double Calculate(double one, double two)
        {
            return func(one, two);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"Name: {Name,-20}   Price: {Price}";
        }
    }





    internal class Program
    {
        static void Sort<T>(T[] arr, Comparison<T> comp)
        {
            Array.Sort(arr, comp);
        }
        static void DrawSquare(int height, ConsoleColor color, char ch)
        {
            Console.ForegroundColor = color;
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                Console.Write(ch);
                for (int j = 0; j < height-2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(ch);
                Console.WriteLine();
            }
            for (int i = 0; i < height; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        static void DrawTriangle(int height, ConsoleColor color, char ch)
        {
            Console.ForegroundColor = color;
            Console.WriteLine();
            for (int i = 0; i < height+1; i++)
            {
                for (int j = 1; j < height-i+1; j++)
                {
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        delegate void Del(int h, ConsoleColor color, char c);
        static void Main(string[] args)
        {
            //DrawSquare(8, ConsoleColor.Green,'*');
            //DrawTriangle(6, ConsoleColor.Red, '*');

            Del del = DrawSquare;
            del += DrawTriangle;

            del(7, ConsoleColor.Cyan, '*');


            Calculator calculator = new Calculator();
            calculator.setOperation(Operation.Div);
            
            Console.WriteLine(calculator.Calculate(90, 33));



            string[] employeeNames = {
                "John Doe",
                "Jane Smith",
                "Mike Johnson",
                "Emily Williams",
                "Chris Brown",
                "Alex Turner",
                "Megan Davis"
            };
            Sort(employeeNames, (x, y) => x.Length.CompareTo(y.Length));
            foreach (var item in employeeNames)
            {
                Console.WriteLine(item);
            }

            Product[] products = {
                new Product("Laptop", 1200),
                new Product("Smartphone", 800),
                new Product("Headphones", 100),
                new Product("Coffee Maker", 50),
                new Product("Smart Watch", 150),
                new Product("TV", 800),
                new Product("Desk Chair", 120),
                new Product("Backpack", 40)
            };

            Console.WriteLine();
            Sort(products, (x, y) => x.Price.CompareTo(y.Price));
            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}