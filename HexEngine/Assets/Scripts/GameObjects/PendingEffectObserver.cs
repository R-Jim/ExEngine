using System.Collections.Generic;
using UnityEngine;

public class PendingEffectObserver : MonoBehaviour
{
    public static Queue<Effect> PendingEffectQueue = new Queue<Effect>();

    private Queue<Effect> ActivatedEffectQueue;

    private List<Model> ModelList;

    // Start is called before the first frame update
    void Start()
    {
        ActivatedEffectQueue = ActivatedEffectObserver.ActivatedEffectQueue;
        ModelList = ModelObserver.ModelList;
    }

    // Update is called once per frame
    void Update()
    {
        if (PendingEffectQueue.Count > 0)
        {
            Effect pendingEfect = PendingEffectQueue.Dequeue();
            if (pendingEfect.EnqueueTick + pendingEfect.OffSet <= SystemProperties.SystemProfile.SystemTick)
            {
                ActivateEffect(pendingEfect);
            }
            else
            {
                PendingEffectQueue.Enqueue(pendingEfect);
            }
        }
    }

    private void ActivateEffect(Effect effect)
    {
        if (effect.Status == Effect.EffectStatus.Pending)
        {
            foreach (Model model in ModelList)
            {
                effect.Activate(model);
            }
        }
        if (effect.Status == Effect.EffectStatus.Activated)
        {
            ActivatedEffectQueue.Enqueue(effect);
        }
    }

    public static void QueueEffect(Effect effect)
    {
        effect.EnqueueTick = SystemProperties.SystemProfile.SystemTick;
        PendingEffectQueue.Enqueue(effect);
    }
}
