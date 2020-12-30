using System.Collections.Generic;

public class EngineFramework : IFramework
{
    public Storage Storage { get; }
    public Model AnchorModel { get; }
    public Coordinate MoveCoordinate { get; }
    public MomentumStorage.Axis Axis { get; }

    public EngineFramework(MomentumStorage.Axis axis)
    {
        CommonPropertySet commonPropertySet = new CommonPropertySet(100, new Coordinate(0, 0, 0));
        AnchorModel = new Model(commonPropertySet);
        MoveCoordinate = CoordinateUtil.GetCoordinate(axis);
        Axis = axis;
    }

    public void Init(Queue<Effect> pendingEffectQueue)
    {

    }

    public void Activate(Queue<Effect> pendingEffectQueue)
    {
        MomentumStorage momentumStorage = new MomentumStorage(Axis, 5);
        MomentumRepeater momentumRepeater = new MomentumRepeater(momentumStorage);
        RepeatEffect.RepeaterProperties repeaterProperties = new RepeatEffect.RepeaterProperties(1, 1, 1);

        MoveEffect moveEffect = new MoveEffect(null, AnchorModel.CommonPropertySet.Coordinate, MoveCoordinate);

        RepeatEffect repeatEffect = new RepeatEffect(null, momentumRepeater, repeaterProperties, moveEffect);

        pendingEffectQueue.Enqueue(repeatEffect);
    }
}
