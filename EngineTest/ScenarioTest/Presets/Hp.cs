using ExtiliaEngine;
using System.Collections.Generic;

public class Hp
{
    public static Instance Get(string id, double baseValue, Instance coordinateInstance)
    {
        DynamicValueFactory valueFactory = new DynamicValueFactory("Value", baseValue, "+");
        Condition typeCondition = new Condition("Types", "in", "Hp");
        Condition coordinateCondination = new Condition("Coordinate", "==", coordinateInstance.Value);
        Trigger trigger = new Trigger(
            new List<Condition>() { typeCondition, coordinateCondination }, null
            );

        return new Instance("Hp" + id, new string[] { "Hp" },
                valueFactory, trigger
            );
    }
}
