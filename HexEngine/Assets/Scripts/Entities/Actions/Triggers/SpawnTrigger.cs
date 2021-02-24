﻿public class SpawnTrigger : Trigger
{
    public const string TYPE = "spawn";

    public SpawnTrigger(Model source, Model spawnModel, int offset)
        : base(source, TYPE, spawnModel.CommonPropertySet.Coordinate, new SpawnEffect(spawnModel), offset)
    {
    }


    public override Effect Hook(Model model)
    {
        string mountType = model.CommonPropertySet.MountType;
        if (mountType != null && mountType.Equals("system"))
        {
            return BaseEffect.Bind(model);
        }
        return null;
    }
}