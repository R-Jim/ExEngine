public class MountPoint
{
    public string Type { get; }
    public Model MountedModel { get; private set; }
    //For rendering mounted model
    public Coordinate Coordinate { get; }

    public MountPoint(string type)
    {
        Type = type;
    }

    public MountPoint(string type, Coordinate coordinate)
    {
        Type = type;
        Coordinate = coordinate;
    }

    public void Mount(Model model)
    {
        MountedModel = model;
        model.CommonPropertySet.MountedTo = this;
    }
}
