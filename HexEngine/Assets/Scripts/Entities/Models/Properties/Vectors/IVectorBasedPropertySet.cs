public interface IVectorBasedPropertySet
{
    public void AddValue(Coordinate.Vector vector, object value);

    public object GetValue(Coordinate.Vector vector);
}
