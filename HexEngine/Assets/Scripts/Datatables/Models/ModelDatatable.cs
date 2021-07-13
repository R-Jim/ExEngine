using System;
using System.Collections.Generic;

public class ModelDatatable : Datatable
{
    protected readonly int COMMON_PROPERTY_INDEX = 0;
    protected readonly int GAMEOBJECT_PROPERTY_INDEX = 1;
    protected readonly int ARMOR_OR_DAMAGE_PROPERTY_INDEX = 2; //From 2-> 7 cause of 6 sides of hexagon
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

    public Model GetModel(object[] inputProperties)
    {
        CommonPropertySet commonPropertySet = (CommonPropertySet)GetDataValue(inputProperties, COMMON_PROPERTY_INDEX);
        GameObjectPropertySet gameObjectPropertySet = (GameObjectPropertySet)GetDataValue(inputProperties, GAMEOBJECT_PROPERTY_INDEX);
        List<MountPoint> MountPointList = new List<MountPoint>();
        for (int i = MOUNTPOINT_START_INDEX; i < DataSets.Length; i++)
        {
            MountPointList.Add((MountPoint)GetDataValue(inputProperties, i));
        }

        return new Model(commonPropertySet, gameObjectPropertySet, MountPointList.ToArray());
    }

    public IVectorBasedPropertySet GetArmorVectorPropertySet()
    {
        if ((PropertyPreset.Preset)DataSets[ARMOR_OR_DAMAGE_PROPERTY_INDEX].Preset != PropertyPreset.Preset.Armor)
        {
            return null;
        }

        VectorBasedIntPropertySet armorVectorPropertySet = new VectorBasedIntPropertySet();
        for (int i = 0; i < 5; i++)
        {
            Coordinate.Vector vector = (Coordinate.Vector)i;
            ArmorPropertySet armorPropertySet = (ArmorPropertySet)GetDataValue(null, i + ARMOR_OR_DAMAGE_PROPERTY_INDEX);
            armorVectorPropertySet.AddValue(vector, armorPropertySet.Value);
        }
        return armorVectorPropertySet;
    }


    public IVectorBasedPropertySet GetDamageVectorPropertySet()
    {
        if ((PropertyPreset.Preset)DataSets[ARMOR_OR_DAMAGE_PROPERTY_INDEX].Preset != PropertyPreset.Preset.Damage)
        {
            return null;
        }

        VectorBasedDamagePropertySet damageVectorPropertySet = new VectorBasedDamagePropertySet();
        for (int i = 0; i < 5; i++)
        {
            Coordinate.Vector vector = (Coordinate.Vector)i;
            DamagePropertySet damagePropertySet = (DamagePropertySet)GetDataValue(null, i + ARMOR_OR_DAMAGE_PROPERTY_INDEX);
            damageVectorPropertySet.AddValue(vector, damagePropertySet.Value);
        }
        return damageVectorPropertySet;
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
