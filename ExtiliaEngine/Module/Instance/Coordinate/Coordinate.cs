namespace ExtiliaEngine
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coordinate cmpObj = (Coordinate)obj;
            return X == cmpObj.X && Y == cmpObj.Y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}