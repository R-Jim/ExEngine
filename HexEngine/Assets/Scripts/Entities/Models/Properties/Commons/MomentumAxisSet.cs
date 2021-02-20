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
        if (Positive == vectorDirection || Negative == vectorDirection)
        {
            return Value;
        }
        return Value / 2;
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
            Value--;
            return Positive;
        }
        Value++;
        return Negative;
    }

    public bool IsEmpty()
    {
        return Value == 0;
    }
}