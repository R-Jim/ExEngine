﻿using System.Collections.Generic;

public class Model
{
    public CommonPropertySet CommonPropertySet { get; }
    public GameObjectPropertySet GameObjectPropertySet { get; }
    public MountPoint[] MountPoints;

    //For animation
    public Queue<Effect> SourceExecutedEffect = new Queue<Effect>();
    public Queue<Effect> TargetExecutedEffect = new Queue<Effect>();

    public Model(CommonPropertySet commonPropertySet, GameObjectPropertySet gameObjectPropertySet) : this(commonPropertySet, gameObjectPropertySet, null)
    {
    }

    public Model(CommonPropertySet commonPropertySet, GameObjectPropertySet gameObjectPropertySet, MountPoint[] mountPoints)
    {
        CommonPropertySet = commonPropertySet;
        GameObjectPropertySet = gameObjectPropertySet;
        MountPoints = mountPoints;
        if(MountPoints != null)
        {
            foreach (MountPoint mountPoint in MountPoints)
            {
                mountPoint.SourceModel = this;
            }
        }
    }

    public virtual bool IsRemovable()
    {
        return CommonPropertySet.HpStorage.IsEmpty();
    }
}
