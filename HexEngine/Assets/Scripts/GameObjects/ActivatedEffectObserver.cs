using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class ActivatedEffectObserver : MonoBehaviour
{
    public static Queue<Effect> ActivatedEffectQueue = new Queue<Effect>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ActivatedEffectQueue.Count > 0)
        {
            Effect activatedEffect = ActivatedEffectQueue.Dequeue();
            //var effectExecutionJob = new EffectExecutionJob() { Effect = activatedEffect };
            //effectExecutionJob.Schedule(ActivatedEffectQueue.Count, 64);
            activatedEffect.Execute(PendingEffectObserver.PendingEffectQueue);
        }
    }
}
