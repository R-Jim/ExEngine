using Unity.Jobs;

public struct EffectExecutionJob : IJobParallelFor
{
    public Effect Effect;

    public void Execute(int index)
    {
        Effect.Execute(PendingEffectObserver.PendingEffectQueue);
    }
}