using PartitioningProblem;

class Program
{
    static void Main(string[] args)
    {
        var random = new Random();

        while (true)
        {
            var a = new HashSet<Element>();
            var b = new HashSet<Element>();

            //a.Add(new Element(8));
            //a.Add(new Element(3));
            //b.Add(new Element(0));
            //b.Add(new Element(2));

            var size = random.Next(2, 10);

            Console.Write("Numbers - ");
            for (int i = 0; i < size; i++)
            {
                var num = random.Next(0, 10);
                Console.Write(num + " ");

                a.Add(new Element(num));
            }

            for (int i = 0; i < size; i++)
            {
                var num = random.Next(0, 10);
                Console.Write(num + " ");

                b.Add(new Element(num));
            }

            var total = a.Sum(i => i.Value) + b.Sum(i => i.Value);

            Console.WriteLine();
            Console.WriteLine("Total - " + total);
            Console.WriteLine("Half - " + total / 2);

            var result = SubsetSum.Partition(a, b);

            Console.WriteLine("Sum - " + result.Sum(element => element.Value));

            foreach (var item in result)
            {
                Console.Write(item.Value + " ");
            }

            Console.WriteLine();
            Console.WriteLine("_________________________");
        }
    }
}