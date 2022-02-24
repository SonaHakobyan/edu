namespace PartitioningProblem
{
    /// <summary>
    /// Represents log information
    /// </summary>
    public class LogData : IComparable<LogData>
    {
        /// <summary>
        /// The swapping element 
        /// </summary>
        public Element Element { get; set; }

        /// <summary>
        /// Determine if element was in A
        /// </summary>
        public bool FormA { get; }

        /// <summary>
        /// Difference of two subsets
        /// </summary>
        public long Difference { get; }

        /// <summary>
        /// Create a new instance of LogData
        /// </summary>
        /// <param name="element"></param>
        /// <param name="formA"></param>
        /// <param name="difference"></param>
        public LogData(Element element, bool formA, long difference)
        {
            this.Element = element;
            this.FormA = formA;
            this.Difference = difference;
        }

        /// <summary>
        /// Compare this to another log
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(LogData? other)
        {
            return Difference.CompareTo(other?.Difference);
        }
    }
}
