namespace PartitioningProblem
{
    public class Element
    {
        public long Value { get; set; }
        public bool Visited { get; set; }

        public Element(long value, bool visited)
        {
            this.Value = value;
            this.Visited = visited;
        }

        public Element(long value) : this(value, false)
        {
        }
    }
}
