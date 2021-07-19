using System.Collections.Generic;

public class DamageUtil
{
    public static void DamageModel(Model sourceModel, Model effectedModel, Coordinate.Vector vector, float impactValue)
    {
        List<DamagePropertySet> damagePropertySetList = GetDamagePropertySets(sourceModel, vector);
        if (damagePropertySetList.Count != 0)
        {
            for (int i = 0; i < damagePropertySetList.Count; i++)
            {
                if (DamageModelArmor(damagePropertySetList[i], impactValue, vector, effectedModel))
                {
                    damagePropertySetList.RemoveAt(i--);
                }
            }

            if (damagePropertySetList.Count == 0)
            {
                effectedModel.CommonPropertySet.Hp -= 1;
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
            if (!damagePropertySet.IsEmpty())
            {
                damagePropertySetList.Add(damagePropertySet);
            }
        }
        return damagePropertySetList;
    }

    // true if armor is broken
    private static bool DamageModelArmor(DamagePropertySet damagePropertySet, float impactValue, Coordinate.Vector incomingVector, Model effectedModel)
    {
        Coordinate.Vector armorVector = CoordinateUtil.RevertVector(incomingVector);
        VectorBasedIntPropertySet armorVectorValuePropertySet = effectedModel.CommonPropertySet.ArmorVectorValuePropertySet;
        int armorValue = (int)armorVectorValuePropertySet.GetValue(armorVector);
        int totalDamage = damagePropertySet.GetDamageValue(impactValue);

        if (armorValue == 0)
        {
            return false;
        }

        armorVectorValuePropertySet.AddValue(armorVector, -totalDamage);
        return (int)armorVectorValuePropertySet.GetValue(armorVector) <= 0;
    }
}
