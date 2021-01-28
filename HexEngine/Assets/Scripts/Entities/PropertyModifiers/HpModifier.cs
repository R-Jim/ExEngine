using UnityEngine;

class HpModifier : Modifier
{
    public HpModifier(int value) : base(value)
    {

    }

    public override void Modify(Effect effect)
    {
        if (effect.Trigger.Source.GetHashCode() == effect.TargetModel.GetHashCode())
        {
            return;
        }
        effect.TargetModel.CommonPropertySet.HpStorage.Fill(-1 * (int)Value);
        effect.Trigger.Source.CommonPropertySet.HpStorage.Fill(-1 * (int)Value);
        Debug.Log("Hit");
    }
}
