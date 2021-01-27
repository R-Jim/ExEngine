public class StorageModel : Model
{
    public StoragePropertySet StoragePropertySet;

    public StorageModel(int max, CommonPropertySet commonPropertySet, GameObjectPropertySet gameObjectPropertySet) : this(max, max, commonPropertySet, gameObjectPropertySet)
    {

    }

    public StorageModel(int max, int current, CommonPropertySet commonPropertySet, GameObjectPropertySet gameObjectPropertySet) : base(commonPropertySet, gameObjectPropertySet)
    {
        StoragePropertySet = new StoragePropertySet(max, current);
    }
}
