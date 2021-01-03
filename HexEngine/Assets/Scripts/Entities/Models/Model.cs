using System.Collections.Generic;

public class Model
{
    public CommonPropertySet CommonPropertySet { get; }
    public Queue<Effect> SourceExecutedEffect = new Queue<Effect>();
    public Queue<Effect> TargetExecutedEffect = new Queue<Effect>();

    public Model(CommonPropertySet commonPropertySet)
    {
        CommonPropertySet = commonPropertySet;
    }

    public virtual bool IsRemovable() {
        return CommonPropertySet.HpCurrent == 0;
    }
}
