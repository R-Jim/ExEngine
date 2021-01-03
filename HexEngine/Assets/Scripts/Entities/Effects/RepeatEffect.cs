using System.Collections.Generic;
using UnityEngine;

public class RepeatEffect : Effect
{
    public const string TYPE = "repeat";
    public IRepeater Repeater { get; }

    RepeaterProperties TickProperties { get; }

    public RepeatEffect(Model source, IRepeater repeater, RepeaterProperties repeaterProperties, Effect repeatEffect) : base(source, null, TYPE, repeatEffect)
    {
        TickProperties = repeaterProperties;
        Repeater = repeater;
    }

    public override void Activate(Model unuseModel)
    {
        if (RepeatTrigger.IsTriggered(Repeater))
        {
            Status = EffectStatus.Activated;
        }
    }

    public override void Execute(Queue<Effect> pendingEffectQueue)
    {
        int currentTick = SystemProperties.SystemProfile.SystemTick;
        if (TickProperties.IsMatchTickRate(currentTick))
        {
            if (Repeater.Repeat())
            {
                pendingEffectQueue.Enqueue(((Effect)Value).Clone());
            }
            else
            {
                Status = EffectStatus.Finished;
                return;
            }
        }
        TickProperties.LastTick = currentTick;
        Status = EffectStatus.Pending;
        pendingEffectQueue.Enqueue(this);
    }

    public override Effect Clone()
    {
        return new RepeatEffect(Source, Repeater, new RepeaterProperties(TickProperties), (Effect) Value);
    }

    public class RepeaterProperties
    {
        public int LastTick = -1;
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

        public RepeaterProperties(RepeaterProperties repeaterProperties)
        {
            BaseTick = repeaterProperties.BaseTick;
            Step = repeaterProperties.Step;
            OffSet = repeaterProperties.OffSet;
        }

        public bool IsMatchTickRate(int CurrentTick)
        {
            if(CurrentTick == LastTick)
            {
                return false;
            }
            int startTick = CurrentTick - OffSet - BaseTick;
            if (startTick < 0)
            {
                return false;
            }
            return startTick == 0 || startTick % Step == 0;
        }
    }
}
