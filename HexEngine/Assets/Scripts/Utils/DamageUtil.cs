using System;
using UnityEngine;

public class DamageUtil
{
    public static void DamageModel(Model effectedModel, Model sourceModel, Coordinate.Vector vectorDirection)
    {
        int impactValue = ImpactDamageUtil.GetImpactValue(sourceModel, vectorDirection);
        int rawDamageValue = CombatPropertySetUtil.GetFullRawDamage(sourceModel, impactValue);
        int trueDamageValue = CombatPropertySetUtil.GetFullTrueDamage(sourceModel, impactValue);

        Debug.Log(sourceModel + ", impactValue:" + impactValue + ", " + rawDamageValue + ", " + trueDamageValue);

        DamageModelWithRawValue(effectedModel, rawDamageValue);
        DamageModelWithTrueValue(effectedModel, trueDamageValue);
    }

    private static void DamageModelWithRawValue(Model effectedModel, int rawDamageValue)
    {
        int damageTaken = (int)Math.Ceiling(GetDamageValueAfterAbsorbtion(effectedModel, rawDamageValue) * CombatPropertySetUtil.GetArmorNullifier(effectedModel));
        effectedModel.CommonPropertySet.HpStorage.Fill(damageTaken);
    }

    private static void DamageModelWithTrueValue(Model effectedModel, int trueDamageValue)
    {
        int damageTaken = GetDamageValueAfterAbsorbtion(effectedModel, trueDamageValue);
        effectedModel.CommonPropertySet.HpStorage.Fill(damageTaken);
    }

    private static int GetDamageValueAfterAbsorbtion(Model effectedModel, int damageValue)
    {
        int totalArmorAbsobtion = CombatPropertySetUtil.GetFullArmorAbsorbtion(effectedModel);
        if (totalArmorAbsobtion == 0)
        {
            return 0;
        }
        return (int)Math.Ceiling(damageValue * CombatPropertySetUtil.GetArmorAbsorbtion(effectedModel) / totalArmorAbsobtion);
    }
}
