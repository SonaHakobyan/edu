namespace PartitioningProblem
{
    /// <summary>
    /// The subset element
    /// </summary>
    public class Element
    {
        /// <summary>
        /// The element value
        /// </summary>
        public long Value { get; set; }

        /// <summary>
        /// Determine if element is visited or not
        /// </summary>
        public bool Visited { get; set; }

        /// <summary>
        /// Create a new instance of element
        /// </summary>
        /// <param name="value"></param>
        /// <param name="visited"></param>
        public Element(long value, bool visited)
        {
            this.Value = value;
            this.Visited = visited;
        }

        /// <summary>
        /// Create a new instance of element
        /// </summary>
        /// <param name="value"></param>
        public Element(long value) : this(value, false)
        {
        }
    }
}
