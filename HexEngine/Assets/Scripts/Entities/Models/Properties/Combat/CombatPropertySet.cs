public class CombatPropertySet
{
    public DamagePropertySet[] DamagePropertySets { get; }
    public ArmorPropertySet[] ArmorPropertySets { get; }

    public CombatPropertySet(DamagePropertySet[] damagePropertySets, ArmorPropertySet[] armorPropertySets)
    {
        DamagePropertySets = damagePropertySets;
        ArmorPropertySets = armorPropertySets;
    }

    public CombatPropertySet()
    {
        DamagePropertySets = new DamagePropertySet[] { };
        ArmorPropertySets = new ArmorPropertySet[] { };
    }
}
