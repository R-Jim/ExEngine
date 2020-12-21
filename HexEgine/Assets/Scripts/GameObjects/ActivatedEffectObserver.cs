using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class ActivatedEffectObserver : MonoBehaviour
{
    public static Queue<Effect> ActivatedEffectQueue;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Effect activatedEffect = ActivatedEffectQueue.Dequeue();
        if (activatedEffect != null)
        {
            var effectExecutionJob = new EffectExecutionJob() { Effect = activatedEffect };
            effectExecutionJob.Schedule(ActivatedEffectQueue.Count, 64);
        }
    }
}
