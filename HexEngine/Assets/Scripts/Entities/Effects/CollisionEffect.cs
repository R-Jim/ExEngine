using UnityEngine;

public class CollisionEffect : Effect
{
    public CollisionEffect(Trigger trigger, int damageValue) : base(trigger, damageValue)
    {

    }

    protected override void ExecuteProcess()
    {
        TargetModel.CommonPropertySet.HpStorage.Fill(-1 * (int)Value);
        Trigger.Source.CommonPropertySet.HpStorage.Fill(-1 * (int)Value);
        Debug.Log("Hit Target, " + TargetModel.CommonPropertySet.HpStorage.ToString()
            + "& Seft, " + Trigger.Source.CommonPropertySet.HpStorage.ToString());
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