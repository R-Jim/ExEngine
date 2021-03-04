using System;

public class MomentumPropertySet
{
    public int YAxis;
    public MomentumAxisSet X { get; } = new MomentumAxisSet(Coordinate.Vector.YZ, Coordinate.Vector.ZY);
    public MomentumAxisSet Y { get; } = new MomentumAxisSet(Coordinate.Vector.XZ, Coordinate.Vector.ZX);
    public MomentumAxisSet Z { get; } = new MomentumAxisSet(Coordinate.Vector.XY, Coordinate.Vector.YX);

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

    public MomentumAxisSet GetMomentumAxisSet(Coordinate coordinate)
    {
        Coordinate.Vector bonusVectorDirection = coordinate.Pivot;
        float x = GetTotalMomentumByDirectionWithBonus(Coordinate.Vector.YZ, bonusVectorDirection);
        float y = GetTotalMomentumByDirectionWithBonus(Coordinate.Vector.XZ, bonusVectorDirection);
        float z = GetTotalMomentumByDirectionWithBonus(Coordinate.Vector.XY, bonusVectorDirection);

        if (Math.Abs(x) > Math.Abs(y) && Math.Abs(x) > Math.Abs(z))
        {
            return X.Clone(1);
        }
        else if (Math.Abs(y) > Math.Abs(z) && Math.Abs(y) > Math.Abs(x))
        {
            return Y.Clone(1);
        }
        return Z.Clone(1);
    }

    public void ConsumeMomentum(Coordinate.Vector vectorDirection)
    {
        if (X.IsAxis(vectorDirection))
        {
            ConsumMomentum(X, Y, Z, vectorDirection);
        }
        else if (Y.IsAxis(vectorDirection))
        {
            ConsumMomentum(Y, X, Z, vectorDirection);
        }
        else if (Z.IsAxis(vectorDirection))
        {
            ConsumMomentum(Z, X, Y, vectorDirection);
        }
    }

    private void ConsumMomentum(MomentumAxisSet main, MomentumAxisSet sub1, MomentumAxisSet sub2, Coordinate.Vector vectorDirection)
    {
        if (!main.IsEmpty())
        {
            main.ConsumeValueByDirection(vectorDirection);
        }
        else
        {
            sub1.ConsumeValueByDirection(vectorDirection);
            sub2.ConsumeValueByDirection(vectorDirection);
        }
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
