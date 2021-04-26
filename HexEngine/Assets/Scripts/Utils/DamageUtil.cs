using System;
using UnityEngine;

public class DamageUtil
{
    public static void DamageModel(Model effectedModel, Model sourceModel, float impactValue)
    {
        int rawDamageValue = CombatPropertySetUtil.GetFullRawDamage(sourceModel, impactValue);
        int trueDamageValue = CombatPropertySetUtil.GetFullTrueDamage(sourceModel, impactValue);

        ModelUtil.ProcessAllModelByFunctionWithInputObjects(effectedModel, DamageModelWithRawValue, new object[] { rawDamageValue });
        ModelUtil.ProcessAllModelByFunctionWithInputObjects(effectedModel, DamageModelWithTrueValue, new object[] { trueDamageValue });
    }

    private static void DamageModelWithRawValue(Model effectedModel, object[] inputObjects)
    {
        int rawDamageValue = (int)inputObjects[0];
        if (effectedModel == null || rawDamageValue == 0)
        {
            return;
        }
        int initialHp = effectedModel.CommonPropertySet.HpStorage.Current;

        int damageTaken = (int)Math.Ceiling(GetDamageValueAfterAbsorbtion(effectedModel, rawDamageValue) * CombatPropertySetUtil.GetArmorNullifier(effectedModel));
        effectedModel.CommonPropertySet.HpStorage.Fill(damageTaken);

        Debug.Log(LoggingUtil.GetModelLoggingIdentifier(effectedModel) + "HP:" + initialHp + " + " + damageTaken + "(R)-> " + effectedModel.CommonPropertySet.HpStorage.Current);
    }

    private static void DamageModelWithTrueValue(Model effectedModel, object[] inputObjects)
    {
        int trueDamageValue = (int)inputObjects[0];
        if (effectedModel == null || trueDamageValue == 0)
        {
            return;
        }
        int initialHp = effectedModel.CommonPropertySet.HpStorage.Current;

        int damageTaken = GetDamageValueAfterAbsorbtion(effectedModel, trueDamageValue);
        effectedModel.CommonPropertySet.HpStorage.Fill(damageTaken);

        Debug.Log(LoggingUtil.GetModelLoggingIdentifier(effectedModel) + "HP:" + initialHp + " + " + damageTaken + "(T)-> " + effectedModel.CommonPropertySet.HpStorage.Current);
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
