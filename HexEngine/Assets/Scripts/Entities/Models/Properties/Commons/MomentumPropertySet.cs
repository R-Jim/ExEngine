using System;

public class MomentumPropertySet
{
    public int YAxis;
    public MomentumAxisSet X { get; } = new MomentumAxisSet(Coordinate.Vector.YZ, Coordinate.Vector.ZY);
    public MomentumAxisSet Y { get; } = new MomentumAxisSet(Coordinate.Vector.XZ, Coordinate.Vector.ZX);
    public MomentumAxisSet Z { get; } = new MomentumAxisSet(Coordinate.Vector.YX, Coordinate.Vector.XY);

    public MomentumPropertySet() : this(0, 0, 0)
    {

    }

    public MomentumPropertySet(int xAxis, int yAxis, int zAxis)
    {
        X.Add(xAxis);
        Y.Add(yAxis);
        Z.Add(zAxis);
    }

    public MomentumPropertySet(VectorPropertySet vectorPropertySet)
    {
        Add(vectorPropertySet);
    }

    public void Add(VectorPropertySet vectorPropertySet)
    {
        X.Add(vectorPropertySet);
        Y.Add(vectorPropertySet);
        Z.Add(vectorPropertySet);
    }

    public Coordinate.Vector GetVectorDirection(Coordinate coordinate)
    {
        Coordinate.Vector bonusVectorDirection = coordinate.Pivot;
        float x = GetTotalMomentumByDirectionWithBonus(Coordinate.Vector.YZ, bonusVectorDirection);
        float y = GetTotalMomentumByDirectionWithBonus(Coordinate.Vector.XZ, bonusVectorDirection);
        float z = GetTotalMomentumByDirectionWithBonus(Coordinate.Vector.XY, bonusVectorDirection);

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

    public float GetTotalMomentumByDirectionWithBonus(Coordinate.Vector vectorDirection, Coordinate.Vector bonusVectorDirection)
    {
        return X.GetValueByDirectionAndBonus(vectorDirection, bonusVectorDirection)
            + Y.GetValueByDirectionAndBonus(vectorDirection, bonusVectorDirection)
            + Z.GetValueByDirectionAndBonus(vectorDirection, bonusVectorDirection);
    }

    public float GetTotalMomentumByDirection(Coordinate.Vector vectorDirection)
    {
        return X.GetValueByDirection(vectorDirection)
            + Y.GetValueByDirection(vectorDirection)
            + Z.GetValueByDirection(vectorDirection);
    }

    public bool IsEmpty()
    {
        return X.IsEmpty() && Y.IsEmpty() && Z.IsEmpty();
    }

    public float GetTotalMomentum()
    {
        return X.Value + Y.Value + Z.Value;
    }
}
