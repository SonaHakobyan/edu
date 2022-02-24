namespace PartitioningProblem
{
    public class SubsetSum
    {
        public static Tuple<HashSet<Element>, HashSet<Element>> Partition(HashSet<Element> set)
        {
            // separate set into to subsets
            var a = set.Take(set.Count / 2).ToHashSet();
            var b = set.TakeLast(set.Count / 2 + set.Count % 2).ToHashSet();

            // sum up elements of each subset
            var sumA = a.Sum(element => element.Value);
            var sumB = b.Sum(element => element.Value);

            // store elements before changing
            var initialA = default(HashSet<Element>);
            var initialB = default(HashSet<Element>);

            // collection to store logs
            var logs = new LinkedList<LogData>();

            while (true)
            {
                // save previous sums of subsets
                var previousSumA = sumA;
                var previousSumB = sumB;

                // store elements before changing
                initialA = new HashSet<Element>(a);
                initialB = new HashSet<Element>(b);

                // as far as there are unvisited elements
                while (a.Any(element => !element.Visited) || b.Any(element => !element.Visited))
                {
                    // sum up elements of each subset
                    sumA = a.Sum(element => element.Value);
                    sumB = b.Sum(element => element.Value);

                    // desired partition found
                    if (sumA == sumB)
                        return new Tuple<HashSet<Element>, HashSet<Element>>(a, b);

                    // find the best element to swap from A to B to make their sums closer
                    var elementOfA = FindClosest(a, (sumA - sumB) / 2);

                    // find the best element to swap from B to A make their sums closer
                    var elementOfB = FindClosest(b, (sumB - sumA) / 2);

                    // no option from B
                    if (elementOfB == null)
                    {
                        // log the step saving difference of subsets at this point
                        logs.AddLast(new LogData(elementOfA, true, Math.Abs(sumA - sumB - 2 * elementOfA.Value)));

                        // mark as visited
                        elementOfA.Visited = true;

                        // swap element
                        a.Remove(elementOfA);
                        b.Add(elementOfA);

                        continue;

                    }

                    // no option from A
                    if (elementOfA == null)
                    {
                        // log the step saving difference of subsets at this point
                        logs.AddLast(new LogData(elementOfB, false, Math.Abs(sumA - sumB - 2 * elementOfB.Value)));

                        // mark as visited
                        elementOfB.Visited = true;

                        // swap element
                        b.Remove(elementOfB);
                        a.Add(elementOfB);

                        continue;
                    }

                    // calculate sums in case swapping from A
                    var newSumAIfFromA = sumA - elementOfA.Value;
                    var newSumBIfFromA = sumB + elementOfA.Value;

                    // calculate sums in case swapping from B
                    var newSumAIfFromB = sumA + elementOfB.Value;
                    var newSumBIfFromB = sumB - elementOfB.Value;

                    // determine the best swap
                    if (Math.Abs(newSumAIfFromA - newSumBIfFromA) < Math.Abs(newSumAIfFromB - newSumBIfFromB))
                    {
                        // log the step saving difference of subsets at this point
                        logs.AddLast(new LogData(elementOfA, true, Math.Abs(newSumAIfFromA - newSumBIfFromA)));

                        // mark as visited
                        elementOfA.Visited = true;

                        // swap element
                        a.Remove(elementOfA);
                        b.Add(elementOfA);
                    }
                    else
                    {
                        // log the step saving difference of subsets at this point
                        logs.AddLast(new LogData(elementOfB, false, Math.Abs(newSumAIfFromB - newSumBIfFromB)));

                        // mark as visited
                        elementOfB.Visited = true;

                        // swap element
                        b.Remove(elementOfB);
                        a.Add(elementOfB);
                    }
                }

                // get the step with minimum difference
                var best = logs.Min();

                // reset subsets
                a = initialA;
                b = initialB;

                foreach (var log in logs)
                {
                    // apply step
                    switch (log.FormA)
                    {
                        case true:
                            a.Remove(log.Element);
                            b.Add(log.Element);
                            break;
                        case false:
                            b.Remove(log.Element);
                            a.Add(log.Element);
                            break;
                    }

                    // reached to the best step
                    if (log == best)
                        break;
                }

                // sum up elements of each subset
                sumA = a.Sum(element => element.Value);
                sumB = b.Sum(element => element.Value);

                // break if iteration result doesn't got better
                if (Math.Abs(sumA - sumB) >= Math.Abs(previousSumA - previousSumB))
                    break;

                // reset logs collection
                logs = new LinkedList<LogData>();

                // mark elements of A unvisited
                foreach (var element in a)
                {
                    element.Visited = false;
                }

                // mark elements of B unvisited
                foreach (var element in b)
                {
                    element.Visited = false;
                }
            }

            // return partitioned subsets
            return new Tuple<HashSet<Element>, HashSet<Element>>(initialA, initialB);
        }

        private static Element FindClosest(HashSet<Element> elements, long k)
        {
            var result = default(Element);

            var closest = long.MaxValue;

            foreach (var element in elements)
            {
                // calculate difference
                var dif = Math.Abs(element.Value - k);

                // try find unvisited element with lower value
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