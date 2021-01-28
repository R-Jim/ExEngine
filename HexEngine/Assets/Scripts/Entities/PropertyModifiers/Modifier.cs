public abstract class Modifier
{
    public object Value { get; }

    protected Modifier(object value)
    {
        Value = value;
    }

    public virtual void Modify(Effect effect)
    {

    }
}
