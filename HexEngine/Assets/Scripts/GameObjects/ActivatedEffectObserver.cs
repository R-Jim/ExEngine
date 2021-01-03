using System.Collections.Generic;
using UnityEngine;

public class ActivatedEffectObserver : MonoBehaviour
{
    public static Queue<Effect> ActivatedEffectQueue = new Queue<Effect>();

    // Update is called once per frame
    void Update()
    {
        if (ActivatedEffectQueue.Count > 0)
        {
            Effect activatedEffect = ActivatedEffectQueue.Dequeue();
            activatedEffect.Execute(PendingEffectObserver.PendingEffectQueue);
            activatedEffect.Source.SourceExecutedEffect.Enqueue(activatedEffect);
            foreach (Model model in activatedEffect.TargetList)
            {
                model.TargetExecutedEffect.Enqueue(activatedEffect);
            }
        }
    }
}
