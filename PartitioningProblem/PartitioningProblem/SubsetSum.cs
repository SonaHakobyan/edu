namespace PartitioningProblem
{
    public class SubsetSum
    {
        public static HashSet<Element> Partition(HashSet<Element> a, HashSet<Element> b)
        {
            long sumA = a.Sum(element => element.Value);
            long sumB = b.Sum(element => element.Value);

            long previousSumA;
            long previousSumB;

            var prevA = default(HashSet<Element>);
            var prevB = default(HashSet<Element>);

            var logs = new LinkedList<LogData>();

            while (true)
            {
                previousSumA = sumA;
                previousSumB = sumB;

                prevA = new HashSet<Element>(a);
                prevB = new HashSet<Element>(b);

                var initialA = new HashSet<Element>(a);
                var initialB = new HashSet<Element>(b);

                while (a.Any(element => !element.Visited) || b.Any(element => !element.Visited))
                {
                    sumA = a.Sum(element => element.Value);
                    sumB = b.Sum(element => element.Value);

                    if (sumA == sumB)
                        return a;

                    var elementOfA = FindClosest(a, (sumA - sumB) / 2);
                    var elementOfB = FindClosest(b, (sumB - sumA) / 2);

                    if (elementOfB == null)
                    {
                        logs.AddLast(new LogData(elementOfA, true, Math.Abs(sumA - sumB - 2 * elementOfA.Value)));

                        elementOfA.Visited = true;

                        a.Remove(elementOfA);
                        b.Add(elementOfA);

                        continue;

                    }
                    else if (elementOfA == null)
                    {
                        logs.AddLast(new LogData(elementOfB, false, Math.Abs(sumA - sumB - 2 * elementOfB.Value)));

                        elementOfB.Visited = true;

                        b.Remove(elementOfB);
                        a.Add(elementOfB);

                        continue;
                    }

                    var newSumAIfFromA = sumA - elementOfA.Value;
                    var newSumBIfFromA = sumB + elementOfA.Value;

                    var newSumAIfFromB = sumA + elementOfB.Value;
                    var newSumBIfFromB = sumB - elementOfB.Value;

                    if (Math.Abs(newSumAIfFromA - newSumBIfFromA) < Math.Abs(newSumAIfFromB - newSumBIfFromB))
                    {
                        logs.AddLast(new LogData(elementOfA, true, Math.Abs(newSumAIfFromA - newSumBIfFromA)));

                        elementOfA.Visited = true;

                        a.Remove(elementOfA);
                        b.Add(elementOfA);
                    }
                    else
                    {
                        logs.AddLast(new LogData(elementOfB, false, Math.Abs(newSumAIfFromB - newSumBIfFromB)));

                        elementOfB.Visited = true;

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

                sumA = a.Sum(element => element.Value);
                sumB = b.Sum(element => element.Value);

                logs = new LinkedList<LogData>();

                foreach (var element in a)
                {
                    element.Visited = false;
                }

                foreach (var element in b)
                {
                    element.Visited = false;
                }

                if (Math.Abs(sumA - sumB) >= Math.Abs(previousSumA - previousSumB))
                {
                    break;
                }
            }

            return prevA;
        }

        private static Element FindClosest(HashSet<Element> elements, long k)
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