public class StorageModel : Model
{
    public StoragePropertySet StoragePropertySet;

    public StorageModel(int max, int current, CommonPropertySet commonPropertySet, GameObjectPropertySet gameObjectPropertySet) : base(commonPropertySet, null, gameObjectPropertySet, null)
    {
        StoragePropertySet = new StoragePropertySet(max, current);
    }
}
