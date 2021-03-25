public class StorageModel : Model
{
    public StoragePropertySet StoragePropertySet;

    public StorageModel(int max, int current, CommonPropertySet commonPropertySet, CombatPropertySet combatPropertySet, GameObjectPropertySet gameObjectPropertySet) : base(commonPropertySet, combatPropertySet, gameObjectPropertySet, null)
    {
        StoragePropertySet = new StoragePropertySet(max, current);
    }
}
