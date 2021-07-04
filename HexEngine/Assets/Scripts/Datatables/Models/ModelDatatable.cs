using System.Collections.Generic;

public class ModelDatatable : Datatable
{
    protected readonly int COMMON_PROPERTY_INDEX = 0;
    protected readonly int GAMEOBJECT_PROPERTY_INDEX = 1;
    protected readonly int DAMAGE_PROPERTY_INDEX = 2; //From 2-> 7 cause of 6 sides of hexagon
    protected readonly int MOUNTPOINT_START_INDEX = 10;
    public string Name { get; }
    public string Description { get; }
    public string Type { get; }
    public int Weight { get; }

    public ActionSet[] ActionSets { get; }

    public ModelDatatable(string name, string description, string type, int weight, DataSet[] properties, ActionSet[] actionSets) : base(properties)
    {
        Name = name;
        Description = description;
        Type = type;
        Weight = weight;
        ActionSets = actionSets;
    }

    public Model GetModel()
    {
        CommonPropertySet commonPropertySet = (CommonPropertySet)GetDataValue(new object[] { }, COMMON_PROPERTY_INDEX);
        GameObjectPropertySet gameObjectPropertySet = (GameObjectPropertySet)GetDataValue(new object[] { }, GAMEOBJECT_PROPERTY_INDEX);
        List<MountPoint> MountPointList = new List<MountPoint>();
        for (int i = MOUNTPOINT_START_INDEX; i < DataSets.Length; i++)
        {
            MountPointList.Add((MountPoint)GetDataValue(new object[] { }, i));
        }

        return new Model(commonPropertySet, gameObjectPropertySet, MountPointList.ToArray());
    }

    public DamagePropertySet GetDamagePropertySet()
    {
        return null;
    }

    public class ActionSet
    {
        public int Key { get; }
        public int PropertyIndex { get; }

        public ActionSet(int key, int propertyIndex)
        {
            Key = key;
            PropertyIndex = propertyIndex;
        }
    }
}
