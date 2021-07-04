using System;

public class Effect
{
    public Trigger Trigger { get; private set; }
    private Action<Effect> PostEffect; //To handle action after effect is executed

    protected Effect()
    {
    }

    public void SetUp(Trigger trigger, Action<Effect> postEffect = null)
    {
        Trigger = trigger;
        PostEffect = postEffect;
    }

    public void Execute(BattleHandler battleHandler, Model targetModel)
    {
        if (Trigger == null)
        {
            throw new Exception("Trigger not found");
        }
        Process(battleHandler, targetModel);
        PostEffect?.Invoke(this);
    }

    protected virtual void Process(BattleHandler battleHandler, Model targetModel)
    {

    }
}