public class MomentumAxisSet
{
    public Coordinate.Vector Positive { get; }
    public Coordinate.Vector Negative { get; }
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

    public float GetValueByDirectionAndBonus(Coordinate.Vector vectorDirection, Coordinate.Vector bonusVectorDirection)
    {
        return GetValueByDirection(vectorDirection) + GetBonus(bonusVectorDirection);
    }

    public float GetValueByDirection(Coordinate.Vector vectorDirection)
    {
        if (IsAxis(vectorDirection))
        {
            return Value;
        }
        return Value / 2;
    }

    public bool IsAxis(Coordinate.Vector vectorDirection)
    {
        return Positive == vectorDirection || Negative == vectorDirection;
    }

    public void ConsumeValueByDirection(Coordinate.Vector vectorDirection)
    {
        if (Positive == vectorDirection)
        {
            Value--;
        }
        else if (Negative == vectorDirection)
        {
            Value++;
        }
        else
        {
            Value *= .5f;
        }
    }

    public float GetBonus(Coordinate.Vector vectorDirection)
    {
        if (vectorDirection == Positive)
        {
            return 1;
        }
        else if (vectorDirection == Negative)
        {
            return -1;
        }
        return 0;
    }

    public Coordinate.Vector GetVectorDirection(float value)
    {
        if (value >= 0)
        {
            return Positive;
        }
        return Negative;
    }

    public bool IsEmpty()
    {
        return Value == 0;
    }
}