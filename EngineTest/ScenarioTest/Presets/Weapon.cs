using ExtiliaEngine;
using System.Collections.Generic;

public class Weapon
{
    public static Instance Get(string id, double baseValue, Instance coordinateInstance)
    {
        DynamicValueFactory valueFactory = new DynamicValueFactory(null, baseValue, null);
        Condition typeCondition = new Condition("Types", "in", "Attact");
        Condition idCondition = new Condition("Types", "in", id);

        Trigger trigger = new Trigger(
            new List<Condition>() { typeCondition, idCondition },
            GetEffectFactory(valueFactory.GetValue(), (Coordinate)coordinateInstance.Value)
            );
        return new Instance("Weapon" + id, new string[] { "Weapon" },
                valueFactory, trigger
            );
    }

    private static EffectFactory GetEffectFactory(object baseValue, Coordinate coordinate)
    {
        Factory coordinateFactory = new Factory("Value", coordinate, "+");
        Factory valueFactory = new Factory(baseValue);
        Factory sourceFactory = new Factory("Target");
        EffectFactory effectFactory = new EffectFactory(
                new string[] { "Damage", "Hp" },
                coordinateFactory,
                valueFactory,
                sourceFactory
            );
        return effectFactory;
    }
}
