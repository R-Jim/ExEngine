using System.Collections.Generic;
using UnityEngine;

public class PendingEffectContainer : MonoBehaviour
{
    public static Queue<Effect> PendingEffectQueue = new Queue<Effect>();

    void Update()
    {
        if (PendingEffectQueue.Count > 0)
        {
            Effect pendingEffect = PendingEffectQueue.Dequeue();
            pendingEffect.Execute();
        }
    }
}
