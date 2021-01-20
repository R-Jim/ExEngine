﻿using System.Collections.Generic;
using UnityEngine;

public class TriggerObserver : MonoBehaviour
{
    public static Queue<Trigger> TriggerQueue = new Queue<Trigger>();

    private Queue<Effect> PendingEffectQueue;

    private List<Model> ModelList;

    // Start is called before the first frame update
    void Start()
    {
        PendingEffectQueue = PendingEffectObserver.PendingEffectQueue;
        ModelList = ModelObserver.ModelList;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerQueue.Count > 0)
        {
            Trigger trigger = TriggerQueue.Dequeue();
            if (trigger.EnqueueTick + trigger.OffSet <= SystemProperties.SystemProfile.SystemTick)
            {
                HookEffect(trigger);
            }
            else
            {
                TriggerQueue.Enqueue(trigger);
            }
        }
    }

    private void HookEffect(Trigger trigger)
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
