using System;

public class MomentumPropertySet
{
    public int YAxis;
    public MomentumAxisSet X = new MomentumAxisSet(Coordinate.VectorDirection.YZ, Coordinate.VectorDirection.ZY);
    public MomentumAxisSet Y = new MomentumAxisSet(Coordinate.VectorDirection.XZ, Coordinate.VectorDirection.ZX);
    public MomentumAxisSet Z = new MomentumAxisSet(Coordinate.VectorDirection.YX, Coordinate.VectorDirection.XY);

    public MomentumPropertySet() : this(0, 0, 0)
    {

    }

    public MomentumPropertySet(int xAxis, int yAxis, int zAxis)
    {
        X.Add(xAxis);
        Y.Add(yAxis);
        Z.Add(zAxis);
    }

    public void Add(Coordinate coordinate)
    {
        X.Add(coordinate.Pivot);
        Y.Add(coordinate.Pivot);
        Z.Add(coordinate.Pivot);
    }

    public Coordinate.VectorDirection GetVectorDirection(Coordinate coordinate)
    {
        Coordinate.VectorDirection vectorDirection = coordinate.Pivot;
        float x = X.GetValueWithBonus(vectorDirection) + Y.GetValueWithBonus(vectorDirection) / 2 + Z.GetValueWithBonus(vectorDirection) / 2;
        float y = X.GetValueWithBonus(vectorDirection) / 2 + Y.GetValueWithBonus(vectorDirection) + Z.GetValueWithBonus(vectorDirection) / 2;
        float z = X.GetValueWithBonus(vectorDirection) / 2 + Y.GetValueWithBonus(vectorDirection) / 2 + Z.GetValueWithBonus(vectorDirection);

        if (Math.Abs(x) > Math.Abs(y) && Math.Abs(x) > Math.Abs(z))
        {
            return X.GetVectorDirection(x);
        }
        else if (Math.Abs(y) > Math.Abs(z) && Math.Abs(y) > Math.Abs(x))
        {
            return Y.GetVectorDirection(y);
        }
        return Z.GetVectorDirection(z);
    }

    public bool IsEmpty()
    {
        return X.IsEmpty() && Y.IsEmpty() && Z.IsEmpty();
    }

    public class MomentumAxisSet
    {
        Coordinate.VectorDirection Positive { get; }
        Coordinate.VectorDirection Negative { get; }
        public float Value { get; private set; }

        public MomentumAxisSet(Coordinate.VectorDirection positive, Coordinate.VectorDirection negative)
        {
            Positive = positive;
            Negative = negative;
            Value = 0;
        }

        public void Add(int value)
        {
            Value += value;
        }

        public void Add(Coordinate.VectorDirection vectorDirection)
        {
            if (vectorDirection == Positive)
            {
                Value++;
            }
            else if (vectorDirection == Negative)
            {
                Value--;
            }
        }

        public float GetValueWithBonus(Coordinate.VectorDirection vectorDirection)
        {
            if (vectorDirection == Positive)
            {
                return Value + 1;
            }
            else if (vectorDirection == Negative)
            {
                return Value - 1;
            }
            return Value;
        }

        public Coordinate.VectorDirection GetVectorDirection(float value)
        {
            if (value >= 0)
            {
                Value--;
                return Positive;
            }
            Value++;
            return Negative;
        }

        public bool IsEmpty()
        {
            return Value <= 0;
        }
    }
}
