using System.Collections.Generic;

public class RepeatEffect : Effect
{
    public const string TYPE = "repeat";

    RepeaterProperties TickProperties { get; }

    public RepeatEffect(Model source, Model repeater, RepeaterProperties repeaterProperties, Effect repeatEffect) : base(source, null, TYPE, repeatEffect)
    {
        TickProperties = repeaterProperties;
        TargetList.Add(repeater);
    }

    new public void Activate(Model unuseModel)
    {
        IRepeater repeater = (IRepeater)TargetList[0];
        if (RepeatTrigger.IsTriggered(TickProperties, repeater))
        {
            Status = EffectStatus.Activated;
        }
    }

    new public void Execute(Queue<Effect> pendingEffectQueue)
    {
        IRepeater repeater = (IRepeater) TargetList[0];
        pendingEffectQueue.Enqueue((Effect)Value);
        if (!repeater.CanRepeat())
        {
            Status = EffectStatus.Finished;
        }
    }

    public class RepeaterProperties
    {
        public int BaseTick { get; }
        public int Step { get; }
        public int OffSet { get; }

        public RepeaterProperties(int step, int systemStep, int offSet)
        {
            Step = step * systemStep;
            if (Step <= 0)
            {
                throw new System.Exception("Step must be larger than 0");
            }
            OffSet = offSet;
        }

        public bool IsMatchTickRate(int CurrentTick)
        {
            int startTick = CurrentTick - OffSet - BaseTick;
            if (startTick < 0)
            {
                return false;
            }
            return startTick == 0 || startTick % Step == 0;
        }
    }
}
