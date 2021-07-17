using System.Collections.Generic;

public class DamageUtil
{
    public static void DamageModel(Model sourceModel, Model effectedModel, Coordinate.Vector vector, float impactValue)
    {
        List<DamagePropertySet> damagePropertySetList = GetDamagePropertySets(sourceModel, vector);
        for (int i = 0; i < damagePropertySetList.Count; i++)
        {
            if (DamageModelArmor(damagePropertySetList[i], impactValue, vector, effectedModel))
            {
                damagePropertySetList.RemoveAt(i--);
            }
        }
    }

    private static List<DamagePropertySet> GetDamagePropertySets(Model model, Coordinate.Vector vector)
    {
        List<DamagePropertySet> damagePropertySetList = new List<DamagePropertySet>();
        Model topModel = CommonPropertySetUtil.GetUpMostModel(model);
        List<Model> modelInCoordinateList = ModelUtil.GetAllModelInCoordinate(topModel, model.CommonPropertySet.Coordinate);
        foreach (Model modelItem in modelInCoordinateList)
        {
            DamagePropertySet damagePropertySet = (DamagePropertySet)modelItem.ModelDatatable.GetDamageVectorPropertySet().GetValue(vector);
            if (damagePropertySet.Value != 0 && damagePropertySet.ImpactValueModifier != 0)
            {
                damagePropertySetList.Add(damagePropertySet);
            }
        }
        return damagePropertySetList;
    }

    // true if armor is broken
    private static bool DamageModelArmor(DamagePropertySet damagePropertySet, float impactValue, Coordinate.Vector vector, Model effectedModel)
    {
        Coordinate.Vector armorDamageVector = CoordinateUtil.RevertVector(vector);
        VectorBasedIntPropertySet armorVectorValuePropertySet = effectedModel.CommonPropertySet.ArmorVectorValuePropertySet;
        int armorValue = (int)armorVectorValuePropertySet.GetValue(armorDamageVector);
        int totalDamage = damagePropertySet.GetDamageValue(impactValue);

        if (armorValue == 0)
        {
            return false;
        }

        armorVectorValuePropertySet.AddValue(armorDamageVector, -totalDamage);
        return (int)armorVectorValuePropertySet.GetValue(armorDamageVector) <= 0;
    }
}
