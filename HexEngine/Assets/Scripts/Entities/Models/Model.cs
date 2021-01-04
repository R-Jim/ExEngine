using System.Collections.Generic;

public class Model
{
    public CommonPropertySet CommonPropertySet { get; }
    public Queue<Effect> SourceExecutedEffect = new Queue<Effect>();
    public Queue<Effect> TargetExecutedEffect = new Queue<Effect>();
    public MountPoint[] MountPoints;

    public Model(CommonPropertySet commonPropertySet) : this(commonPropertySet, null)
    {
    }

    public Model(CommonPropertySet commonPropertySet, MountPoint[] mountPoints)
    {
        CommonPropertySet = commonPropertySet;
        MountPoints = mountPoints;
    }

    public virtual bool IsRemovable() {
        return CommonPropertySet.HpCurrent == 0;
    }
}
