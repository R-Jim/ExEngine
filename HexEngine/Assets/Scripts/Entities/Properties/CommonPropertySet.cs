public class CommonPropertySet
{
    public int HpMax { get; }
    public int HpCurrent { get; }
    public Coordinate Coordinate { get; }
	public string GroupId;

    public CommonPropertySet(int hpMax, Coordinate coordinate) : this(hpMax, hpMax, coordinate)
    {

    }

    public CommonPropertySet(int hpMax, int hpCurrent, Coordinate coordinate)
    {
        HpMax = hpMax;
        HpCurrent = hpCurrent;
        Coordinate = coordinate;
    }
}
