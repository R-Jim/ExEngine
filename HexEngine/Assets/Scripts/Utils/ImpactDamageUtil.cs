using System;

class ImpactDamageUtil
{
    public static void Damage(Model sourceModel, Model effectedModel)
    {
        DamageModel(effectedModel, GetDamageValue(sourceModel));
        DamageModel(sourceModel, GetDamageValue(effectedModel));
    }

    private static void DamageModel(Model model, int damage)
    {
        int numberOfMountedModel = CommonPropertySetUtil.GetFullMountedModelCount(model);
        model.CommonPropertySet.HpStorage.Fill(-1 * damage / numberOfMountedModel);
    }

    private static int GetDamageValue(Model model)
    {
        return (int)Math.Round(CommonPropertySetUtil.GetFullWeight(model) * (model.CommonPropertySet.MomentumPropertySet.GetTotalMomentum() + 1));
    }
}
