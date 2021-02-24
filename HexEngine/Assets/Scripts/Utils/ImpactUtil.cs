using System;

class ImpactUtil
{
    public static float GetImpactValue(Model model, Coordinate.Vector vectorDirection)
    {
        MomentumAxisSet speedAxisSet = model.CommonPropertySet.SpeedAxisSet;
        float speedValue = speedAxisSet != null ? speedAxisSet.GetValueByDirection(vectorDirection) : 0;
        int modelWeight = CommonPropertySetUtil.GetFullWeight(model);
        return (speedValue == 0) ? 0 : modelWeight * (speedValue / Math.Abs(speedValue));
    }
}
