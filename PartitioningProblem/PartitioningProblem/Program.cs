using PartitioningProblem;

public class Program
{
    static void Main(string[] args)
    {
        var random = new Random();

        while (true)
        {
            // the partition set
            var set = new HashSet<Element>();

            // the size of set
            var size = random.Next(2, 50);

            for (var i = 0; i < size; i++)
            {
                // generate a random number
                var num = random.Next(0, 100);

                // insert into set
                set.Add(new Element(num));

                Console.Write($"{num} ");
            }

            // sup up set elements
            var total = set.Sum(i => i.Value);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Total Sum - {total}");
            Console.WriteLine($"Half Sum - { total / 2}");
            Console.WriteLine();

            // run partition algorithm throw set and get subsets
            var (firstSubset, secondSubset ) = SubsetSum.Partition(set);

            Console.WriteLine($"First Subset Sum - { firstSubset.Sum(element => element.Value)}");

            foreach (var item in firstSubset)
            {
                Console.Write($"{item.Value} ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Second Subset Sum - { secondSubset .Sum(element => element.Value)}");

            foreach (var item in secondSubset )
            {
                Console.Write($"{item.Value} ");
            }

            Console.WriteLine();
            Console.WriteLine("_________________________");
        }
    }
}