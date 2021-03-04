using System.Collections.Generic;
using UnityEngine;

public class TriggerContainer : MonoBehaviour
{
    public static Queue<Trigger> TriggerQueue = new Queue<Trigger>();

    private Queue<Effect> PendingEffectQueue;

    private List<Model> ModelList;

    void Start()
    {
        PendingEffectQueue = PendingEffectContainer.PendingEffectQueue;
        ModelList = ModelContainer.ModelList;
    }

    void Update()
    {
        if (TriggerQueue.Count > 0)
        {
            Trigger trigger = TriggerQueue.Dequeue();
            if (trigger.EnqueueTick + trigger.OffSet <= SystemProperties.SystemProfile.SystemTick)
            {
                CheckHook(trigger);
            }
            else
            {
                TriggerQueue.Enqueue(trigger);
            }
        }
    }

    private void CheckHook(Trigger trigger)
    {
        foreach (Model model in ModelList)
        {
            Effect effect = trigger.Hook(model);
            if(effect != null)
            {
                PendingEffectQueue.Enqueue(effect);
            }
        }
    }

    public static void QueueTrigger(Trigger trigger)
    {
        trigger.EnqueueTick = SystemProperties.SystemProfile.SystemTick;
        TriggerQueue.Enqueue(trigger);
    }
}
