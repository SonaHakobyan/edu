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

            var size = random.Next(6, 50);

            Console.Write("Numbers - ");
            for (int i = 0; i < size/2; i++)
            {
                var num = random.Next(0, 100);
                Console.Write(num + " ");

                a.Add(new Element(num));
            }

            for (int i = 0; i < size / 2 + 1; i++)
            {
                var num = random.Next(0, 100);
                Console.Write(num + " ");

                b.Add(new Element(num));
            }

            var total = a.Sum(i => i.Value) + b.Sum(i => i.Value);
            var randomNum = total / 2; // random.Next(0, 100);

            Console.WriteLine();
            Console.WriteLine("Total - " + total);
            Console.WriteLine("Half - " + randomNum);
            //Console.WriteLine("K - " + randomNum);

            var result = SubsetSum.Partition(a, b, randomNum);

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