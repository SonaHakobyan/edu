namespace PartitioningProblem
{
    public class SubsetSum
    {
        public static HashSet<Element> Partition(HashSet<Element> a, HashSet<Element> b, long k)
        {
            long previousSum = -1;
            long currentSum = -1;
            var logs = new LinkedList<LogData>();
            var prevA = new HashSet<Element>(a);

            while (true)
            {
                previousSum = currentSum;
                prevA = new HashSet<Element>(a);

                var initialA = new HashSet<Element>(a);
                var initialB = new HashSet<Element>(b);

                while (a.Any(element => !element.Visited) || b.Any(element => !element.Visited))
                {
                    currentSum = a.Sum(element => element.Value);

                    if (currentSum == k)
                        return a;

                    var elementOfA = findClosest(a, currentSum - k);
                    var elementOfB = findClosest(b, k - currentSum);

                    if (elementOfB == null)
                    {
                        logs.AddLast(new LogData(elementOfA, true, Math.Abs(k - currentSum + elementOfA.Value)));

                        elementOfA.Visited = true;

                        a.Remove(elementOfA);
                        b.Add(elementOfA);

                        continue;

                    }
                    else if (elementOfA == null)
                    {
                        logs.AddLast(new LogData(elementOfB, false, Math.Abs(k - currentSum - elementOfB.Value)));

                        elementOfB.Visited = true;

                        b.Remove(elementOfB);
                        a.Add(elementOfB);

                        continue;
                    }

                    var newSumIfA = currentSum - elementOfA.Value;
                    var newSumIfB = currentSum + elementOfB.Value;

                    if (Math.Abs(k - newSumIfA) < Math.Abs(k - newSumIfB))
                    {
                        logs.AddLast(new LogData(elementOfA, true, Math.Abs(k - newSumIfA)));

                        elementOfA.Visited = true;

                        a.Remove(elementOfA);
                        b.Add(elementOfA);
                    }
                    else
                    {
                        logs.AddLast(new LogData(elementOfB, false, Math.Abs(k - newSumIfB)));

                        elementOfB.Visited=true;

                        b.Remove(elementOfB);
                        a.Add(elementOfB);
                    }
                }

                var best = logs.Min();

                a = initialA;
                b = initialB;

                foreach (var log in logs)
                {
                    if (log.FormA)
                    {
                        a.Remove(log.Element);
                        b.Add(log.Element);
                    }
                    else if (!log.FormA)
                    {
                        b.Remove(log.Element);
                        a.Add(log.Element);
                    }

                    if (log == best)
                        break;
                }

                currentSum = a.Sum(element => element.Value);   

                logs = new LinkedList<LogData>();

                foreach (var element in a)
                {
                    element.Visited = false;
                }

                foreach (var element in b)
                {
                    element.Visited = false;
                }

                if(Math.Abs(k - previousSum) <= Math.Abs(k - currentSum))
                {
                    break;
                }
            }

            return prevA;
        }

        private static Element findClosest(HashSet<Element> elements, long k)
        {
            var result = default(Element);

            long closest = long.MaxValue;

            foreach (var element in elements)
            {
                long dif = Math.Abs(element.Value - k);
                if (!element.Visited && dif < closest)
                {
                    closest = dif;
                    result = element;
                }
            }
            return result;
        }
    }
}