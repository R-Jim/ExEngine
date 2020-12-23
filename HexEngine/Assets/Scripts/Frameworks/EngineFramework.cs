public class EngineFramework : Framework
{
    public Storage Storage;
    public Model AnchorModel;

    public EngineFramework()
    {
        CommonPropertySet commonPropertySet = new CommonPropertySet(100, new Coordinate(0, 0, 0));
        AnchorModel = new Model(commonPropertySet);
    }

    public void Ignite()
    {
        MomentumStorage momentumStorage = new MomentumStorage(MomentumStorage.Axis.X, 5);
        MomentumRepeater momentumRepeater = new MomentumRepeater(momentumStorage);
        RepeatEffect.RepeaterProperties repeaterProperties = new RepeatEffect.RepeaterProperties(1, 1, 0);

        MoveEffect moveEffect = new MoveEffect(null, AnchorModel.CommonPropertySet.Coordinate, new Coordinate(1, 0, 0));

        RepeatEffect repeatEffect = new RepeatEffect(null, momentumRepeater, repeaterProperties, moveEffect);

        PendingEffectObserver.PendingEffectQueue.Enqueue(repeatEffect);
    }
}
