using System;
using UnityEngine;

public class DamageUtil
{
    public static void DamageModel(Model effectedModel, Model sourceModel, float impactValue)
    {
        int rawDamageValue = CombatPropertySetUtil.GetFullRawDamage(sourceModel, impactValue);
        int trueDamageValue = CombatPropertySetUtil.GetFullTrueDamage(sourceModel, impactValue);

        if (rawDamageValue != 0)
        {
            ModelUtil.ProcessAllModelByFunctionWithInputObjects(effectedModel, DamageModelWithValue, new object[] { rawDamageValue, true });
        }
        if (trueDamageValue != 0)
        {
            ModelUtil.ProcessAllModelByFunctionWithInputObjects(effectedModel, DamageModelWithValue, new object[] { trueDamageValue, false });
        }
    }

    private static void DamageModelWithValue(Model effectedModel, object[] inputObjects)
    {
        int fullDamageValue = (int)inputObjects[0];
        bool isTrueDamage = (bool)inputObjects[1];
        int initialHp = effectedModel.CommonPropertySet.HpStorage.Current;
        int damageTaken = isTrueDamage ? GetReceivedTrueDamageValue(effectedModel, inputObjects) : GetReceivedRawDamageValue(effectedModel, inputObjects);

        effectedModel.CommonPropertySet.HpStorage.Fill(damageTaken);

        Debug.Log(LoggingUtil.GetModelLoggingIdentifier(effectedModel) + "HP:" + initialHp + " + " + damageTaken + "/" + fullDamageValue + (isTrueDamage ? "(T)" : "") + "-> " + effectedModel.CommonPropertySet.HpStorage.Current);
    }

    public static int GetReceivedRawDamageValue(Model effectedModel, object[] inputObjects)
    {
        int rawDamageValue = (int)inputObjects[0];
        if (effectedModel == null || rawDamageValue == 0)
        {
            return 0;
        }
        return (int)Math.Ceiling(GetDamageValueAfterAbsorbtion(effectedModel, rawDamageValue) * CombatPropertySetUtil.GetArmorNullifier(effectedModel));
    }

    public static int GetReceivedTrueDamageValue(Model effectedModel, object[] inputObjects)
    {
        int trueDamageValue = (int)inputObjects[0];
        if (effectedModel == null || trueDamageValue == 0)
        {
            return 0;
        }
        return GetDamageValueAfterAbsorbtion(effectedModel, trueDamageValue);
    }

    private static int GetDamageValueAfterAbsorbtion(Model effectedModel, int damageValue)
    {
        if (effectedModel == null)
        {
            return 0;
        }
        int totalArmorAbsobtion = CombatPropertySetUtil.GetFullArmorAbsorbtion(effectedModel);
        if (totalArmorAbsobtion == 0)
        {
            return 0;
        }
        return (int)Math.Ceiling(damageValue * CombatPropertySetUtil.GetArmorAbsorbtion(effectedModel) / totalArmorAbsobtion);
    }
}
