public class HpModifier : Modifier
{
    public HpModifier(int value) : base(value)
    {

    }

    public override void Modify(BattleHandler battleHandler, Model model)
    {
        model.CommonPropertySet.HpStorage.Fill((int)Value);
    }
}
