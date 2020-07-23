using ExtiliaEngine;
using System.Collections.Generic;

public class LockInvoker
{
    public static Instance Get(string id, string[] instanceTypes, int lockTime)
    {
        List<Condition> conditions = new List<Condition>();
        foreach(string instanceType in instanceTypes)
        {
            conditions.Add(new Condition("Types", "in", instanceType));
        }
        EffectFactory effectFactory = new EffectFactory(
                new string[] { id, "Lock" }, null, new Factory(lockTime), new Factory("Target")
            );
        Trigger trigger = new Trigger(conditions, effectFactory);

        return new Instance("Lock" + id, new string[] { "LockInvoker", id },
                null, trigger
            );
    }
}
