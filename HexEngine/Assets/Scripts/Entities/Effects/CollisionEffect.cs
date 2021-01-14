using UnityEngine;

public class CollisionEffect : Effect
{
    public const string TYPE = "collision";
    private const int COLLISION_DAMAGE = 10;

    public CollisionEffect(Model source, Coordinate coordinate, int offset) : base(source, coordinate, TYPE, COLLISION_DAMAGE, offset)
    {

    }


    public override void Activate(Model target)
    {
        if (CollisionTrigger.IsTriggered(target, this))
        {
            TargetList.Add(target);
            Status = EffectStatus.Activated;
        }
    }

    public override void Execute()
    {
        foreach (Model target in TargetList)
        {
            target.CommonPropertySet.HpCurrent -= (int)Value;
            Source.CommonPropertySet.HpCurrent -= (int)Value;
            Debug.Log("Hit Target, " + target.CommonPropertySet.HpMax + "/" + target.CommonPropertySet.HpCurrent + "| Seft, " + Source.CommonPropertySet.HpMax + "/" + Source.CommonPropertySet.HpCurrent);
        }
        Status = EffectStatus.Finished;
    }

    public override Effect Clone()
    {
        return new CollisionEffect(Source, Coordinate, OffSet);
    }
}