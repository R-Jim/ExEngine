using ExtiliaEngine;
using System.Collections.Generic;

public class Invoker
{

    private readonly string Id = "Invoker";
    private readonly Coordinate Coordinate;

    public Invoker(int number, Coordinate coordinate)
    {
        Id += number;
        Coordinate = coordinate;
    }

    public List<Instance> Get()
    {
        Instance CoordinateInstance = GetCoordinateInstance();
        return new List<Instance>()
        {
            GetMainInstance(),
            CoordinateInstance,
            GetHpInstance(CoordinateInstance),
            GetWeaponInstance(CoordinateInstance)
        };
    }

    private Instance GetMainInstance()
    {
        string[] invokerTypes = new string[] {
        "Invoker", "Main", "Team2"
    };
        return new Instance(Id,
            invokerTypes, null, null);
    }

    private Instance GetCoordinateInstance()
    {
        return CoordinateInstance.Get(Id, Coordinate);
    }

    private Instance GetHpInstance(Instance CoordinateInstance)
    {
        return Hp.Get(Id, 100, CoordinateInstance);
    }

    private Instance GetWeaponInstance(Instance CoordinateInstance)
    {
        return Weapon.Get(Id, 10, CoordinateInstance);
    }
}
