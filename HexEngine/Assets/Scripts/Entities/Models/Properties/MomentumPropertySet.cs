using System;

public class MomentumPropertySet
{
    public int YAxis;
    public MomentumAxisSet X { get; }
    public MomentumAxisSet Y { get; }
    public MomentumAxisSet Z { get; }

    public MomentumPropertySet() : this(0, 0, 0)
    {

    }

    public MomentumPropertySet(int xAxis, int yAxis, int zAxis)
    {
        X = new MomentumAxisSet(Coordinate.Vector.YZ, Coordinate.Vector.ZY);
        Y = new MomentumAxisSet(Coordinate.Vector.XZ, Coordinate.Vector.ZX);
        Z = new MomentumAxisSet(Coordinate.Vector.YX, Coordinate.Vector.XY);
        X.Add(xAxis);
        Y.Add(yAxis);
        Z.Add(zAxis);
    }

    public void Add(VectorPropertySet vectorPropertySet)
    {
        X.Add(vectorPropertySet);
        Y.Add(vectorPropertySet);
        Z.Add(vectorPropertySet);
    }

    public Coordinate.Vector GetVectorDirection(Coordinate coordinate)
    {
        Coordinate.Vector vectorDirection = coordinate.Pivot;
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
        Coordinate.Vector Positive { get; }
        Coordinate.Vector Negative { get; }
        public float Value { get; private set; }

        public MomentumAxisSet(Coordinate.Vector positive, Coordinate.Vector negative)
        {
            Positive = positive;
            Negative = negative;
            Value = 0;
        }

        public void Add(int value)
        {
            Value += value;
        }

        public void Add(VectorPropertySet vectorPropertySet)
        {
            if (vectorPropertySet.Vector == Positive)
            {
                Value += vectorPropertySet.Multiplier;
            }
            else if (vectorPropertySet.Vector == Negative)
            {
                Value -= vectorPropertySet.Multiplier;
            }
        }

        public float GetValueWithBonus(Coordinate.Vector vectorDirection)
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

        public Coordinate.Vector GetVectorDirection(float value)
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
