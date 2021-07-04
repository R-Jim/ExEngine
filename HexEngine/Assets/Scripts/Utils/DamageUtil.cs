public class DamageUtil
{
    public static void DamageModel(Model sourceModel, Model effectedModel, Coordinate.Vector vector)
    {
        DamageValue damageValue = new DamageValue(CombatPropertySetUtil.GetFullDamage(sourceModel, vector));
        ModelUtil.ProcessAllModelByFunctionWithInputObjects(effectedModel, DamageModelArmorWithValue, new object[] { damageValue, vector });
        if (damageValue.Value > 0)
        {
            effectedModel.CommonPropertySet.Hp -= damageValue.Value;
        }
    }

    private static void DamageModelArmorWithValue(Model effectedModel, object[] inputObjects)
    {
        DamageValue damageValue = (DamageValue)inputObjects[0];
        Coordinate.Vector vector = CoordinateUtil.RevertVector((Coordinate.Vector)inputObjects[1]);
        int armorValue = effectedModel.CommonPropertySet.ArmorValuePropertySet.GetValue(vector);

        int remainDamageValue = damageValue.Value - armorValue;
        if (remainDamageValue < 0)
        {
            effectedModel.CommonPropertySet.ArmorValuePropertySet.AddValue(vector, -damageValue.Value);
        }
        else
        {
            effectedModel.CommonPropertySet.ArmorValuePropertySet.AddValue(vector, -armorValue);
            damageValue.Value = remainDamageValue;
        }
    }

    class DamageValue
    {
        public int Value;

        public DamageValue(int value)
        {
            Value = value;
        }
    }
}
