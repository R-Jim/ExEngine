using ExtiliaEngine;
using System.Collections.Generic;

public class Lock
{
    public static Instance Get(string id, string instanceType)
    {
        DynamicValueFactory valueFactory = new DynamicValueFactory("Value", 0, "+");
        Condition typeCondition = new Condition("Types", "in", "Lock");
        Condition instanceTypeCondition = new Condition("Types", "in", instanceType);
        Trigger trigger = new Trigger(
            new List<Condition>() { typeCondition, instanceTypeCondition }, null
            );

        return new Instance("Lock" + id, new string[] { "Lock" },
                valueFactory, trigger
            );
    }
}
