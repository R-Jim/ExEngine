using System.Collections.Generic;
using UnityEngine;

public class PendingEffectObserver : MonoBehaviour
{
    public static Queue<Effect> PendingEffectQueue;

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
        Effect pendingEfect = PendingEffectQueue.Dequeue();
        if(pendingEfect != null)
        {
            foreach(Model model in ModelList)
            {
                pendingEfect.Activate(model);
            }
            if(pendingEfect.Status == Effect.EffectStatus.Activated)
            {
                ActivatedEffectQueue.Enqueue(pendingEfect);
            }
        }
    }
}
