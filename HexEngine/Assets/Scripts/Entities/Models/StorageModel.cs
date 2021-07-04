public class StorageModel : Model
{
    private int Current;
    public StoragePropertySet StoragePropertySet;

    public StorageModel(int current, CommonPropertySet commonPropertySet, GameObjectPropertySet gameObjectPropertySet, MountPoint[] mountPoints) : base(commonPropertySet, gameObjectPropertySet, mountPoints)
    {
        Current = current;
    }

    public int Get(int value)
    {
        if (Current >= value)
        {
            return value;
        }
        else
        {
            return 0;
        }
    }

    public void Fill(int value)
    {
        Current += value;
        int maxValue = ((StorageModelDatatable)ModelDatatable).Max;
        if (Current > maxValue)
        {
            Current = maxValue;
        }
        else if (Current <= 0)
        {
            Current = 0;
        }
    }

    public bool IsEmpty()
    {
        return Current <= 0;
    }

}
