using System;

public class CombatPropertySetUtil
{
    public static int GetFullRawDamage(Model model, float impactValue)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(model);
        return (int)Math.Ceiling(ModelUtil.GetModelFullPropertyByFunctionWithInputObjects(upMostModel, GetDamage, new object[] { impactValue, false }));
    }


    public static int GetFullTrueDamage(Model model, float impactValue)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(model);
        return (int)Math.Ceiling(ModelUtil.GetModelFullPropertyByFunctionWithInputObjects(upMostModel, GetDamage, new object[] { impactValue, true }));
    }

    public static float GetDamage(Model model, object[] inputObjects)
    {
        float impactValue = (int)inputObjects[0];
        bool isTrueDamage = (bool)inputObjects[1];
        float totalDamage = 0;
        DamagePropertySet[] damagePropertySets = model.CombatPropertySet.DamagePropertySets;
        foreach (DamagePropertySet damagePropertySet in damagePropertySets)
        {
            if (damagePropertySet.IsTrueDamage == isTrueDamage)
            {
                totalDamage += damagePropertySet.GetDamageValue(impactValue);
            }
        }
        return totalDamage;
    }

    public static int GetFullArmorAbsorbtion(Model model)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(model);
        return (int)Math.Ceiling(ModelUtil.GetModelFullPropertyByFunction(upMostModel, GetArmorAbsorbtion));
    }

    public static float GetArmorAbsorbtion(Model model)
    {
        float total = 0;
        ArmorPropertySet[] armorPropertySets = model.CombatPropertySet.ArmorPropertySets;
        foreach (ArmorPropertySet armorPropertySet in armorPropertySets)
        {
            total += armorPropertySet.Absobtion;
        }
        return total;
    }

    public static float GetFullArmorNullifier(Model model)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(model);
        return ModelUtil.GetModelFullPropertyByFunction(upMostModel, GetArmorNullifier);
    }

    public static float GetArmorNullifier(Model model)
    {
        float total = 0;
        ArmorPropertySet[] armorPropertySets = model.CombatPropertySet.ArmorPropertySets;
        foreach (ArmorPropertySet armorPropertySet in armorPropertySets)
        {
            total += armorPropertySet.Nullifier;
        }
        return total;
    }
}
