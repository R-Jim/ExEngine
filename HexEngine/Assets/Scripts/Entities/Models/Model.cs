public class Model
{
    public CommonPropertySet CommonPropertySet { get; }

    public Model(CommonPropertySet commonPropertySet)
    {
        CommonPropertySet = commonPropertySet;
    }

    public virtual bool IsRemovable() {
        return CommonPropertySet.HpCurrent == 0;
    }
}
