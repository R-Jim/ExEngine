public abstract class Modifier
{
    public object Value { get; }

    protected Modifier(object value)
    {
        Value = value;
    }

    public virtual void Modify(BattleHandler battleHandler, Model targetModel)
    {

    }
}
