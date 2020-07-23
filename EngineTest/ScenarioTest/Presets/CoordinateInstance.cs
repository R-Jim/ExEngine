using ExtiliaEngine;
using System.Collections.Generic;

public class CoordinateInstance
{
    public static Instance Get(string id, Coordinate baseValue, Instance moveLock)
    {
        DynamicValueFactory valueFactory = new DynamicValueFactory("Value", baseValue, "+");
        Condition typeCondition = new Condition("Types", "in", "Coordinate");
        Condition coordinateCondition = new Condition("Coordinate", "==", valueFactory.GetValue());
        Condition lockCondition = new BindedObjectCondition(moveLock, "Value", "==", false, "Value");
        Trigger trigger = new Trigger(
            new List<Condition>() { typeCondition, coordinateCondition, lockCondition }, null
            );

        return new Instance("Coordinate" + id, new string[] { "Coordinate" },
                                valueFactory, trigger);
    }
}
