using PartitioningProblem;

public class Program
{
    public const double ITERATION_SIZE = 100;
    //public const int SET_SIZE = 25000;
    public const int RANGE_FROM = 10;
    public const int RANGE_TO = 100000;

    static void Main(string[] args)
    {
        Console.WriteLine("SET_SIZE");
        int SET_SIZE = Convert.ToInt32(Console.ReadLine());

        var random = new Random();
        var iterations = 0;
        var faults = 0;
        double errorRate = 0;
        
        while (iterations < ITERATION_SIZE - 1)
        {
            var set = new HashSet<int>();

            while (set.Count < SET_SIZE - 1)
            {
                set.Add(random.Next(RANGE_FROM, RANGE_TO));
            }

            var setSum1 = set.Take(set.Count / 2).Sum();
            var setSum2 = set.TakeLast(set.Count / 2 + set.Count % 2).Sum();

            var diffSum = Math.Abs(setSum1 - setSum2);
            if (set.Contains(diffSum))
            {
                continue;
            };
            set.Add(diffSum);

            var result = SubsetSum.Partition(set);

            double s1 = result.A.Sum(element => element.Value);
            double s2 = result.B.Sum(element => element.Value);

            if (s1 != s2)
            {
                faults++;
                var actualResult = set.Sum() / 2;
                var accuracy = 100 * (Math.Min(s1, s2) / actualResult);
                errorRate += 100 - accuracy;
            }

            iterations++;
        }

        using StreamWriter output = new(@"C:\Users\Sona.Hakobyan\source\repos\edu\PartitioningProblem\output.txt", true);
        output.WriteLine($"ITERATION_SIZE - {ITERATION_SIZE}");
        output.WriteLine($"SET_SIZE - {SET_SIZE}");
        output.WriteLine($"RANGE_FROM - {RANGE_FROM}");
        output.WriteLine($"RANGE_TO - {RANGE_TO}");
        output.WriteLine($"FAULTS - {faults }");
        output.WriteLine($"FAULTS_ERROR_RATE - {errorRate / faults }%");
        output.WriteLine($"ERROR_RATE - {errorRate / ITERATION_SIZE }%");
        output.WriteLine();
    }
}