public class TempPropertyInterval : Interval
{
    public TempPropertyInterval(BattleHandler battleHandler) : base(1, battleHandler)
    {

    }

    protected override void Process()
    {
        foreach (Model model in BattleHandler.GetModels())
        {

        }
    }
}
