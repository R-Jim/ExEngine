public interface IVectorBasedPropertySet
{
    void AddValue(Coordinate.Vector vector, object value);

    object GetValue(Coordinate.Vector vector);
}
