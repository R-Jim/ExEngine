using System.Collections.Generic;

public interface IFramework
{
    void Init(Queue<Effect> pendingEffectQueue);

    void Activate(Queue<Effect> pendingEffectQueue);
}
