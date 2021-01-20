using UnityEngine;

public class CollisionEffect : Effect
{
    public CollisionEffect(Trigger trigger, int damageValue) : base(trigger, damageValue)
    {

    }

    public override void Execute()
    {
        TargetModel.CommonPropertySet.HpCurrent -= (int)Value;
        Trigger.Source.CommonPropertySet.HpCurrent -= (int)Value;
        Debug.Log("Hit Target, " + TargetModel.CommonPropertySet.HpMax + "/" + TargetModel.CommonPropertySet.HpCurrent
            + "& Seft, " + Trigger.Source.CommonPropertySet.HpMax + "/" + Trigger.Source.CommonPropertySet.HpCurrent);
        Status = EffectStatus.Executed;
        AssignEffectAfterExecuted();
    }

    public override Effect Bind(Model model)
    {
        Effect effect = new CollisionEffect(Trigger, (int)Value)
        {
            TargetModel = model
        };
        return effect;
    }
}