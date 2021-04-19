public class HpModifier : Modifier
{
    public HpModifier(int value) : base(value)
    {

    }

    public override void Modify(Effect effect, BattleHandler battleHandler)
    {
        effect.TargetModel.CommonPropertySet.HpStorage.Fill((int)Value);
    }
}
