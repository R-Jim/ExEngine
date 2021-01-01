using System.Collections.Generic;
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
            activatedEffect.Execute(PendingEffectObserver.PendingEffectQueue);
        }
    }
}
