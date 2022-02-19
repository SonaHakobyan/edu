namespace PartitioningProblem
{
    public class LogData : IComparable<LogData>
    {
        public Element Element { get; set; }
        public bool FormA { get; private set; }
        public long Differance { get; private set; }

        public LogData(Element element, bool formA, long differance)
        {
            this.Element = element;
            this.FormA = formA;
            this.Differance = differance;
        }

        public int CompareTo(LogData? other)
        {
            return Differance.CompareTo(other?.Differance);
        }
    }
}
