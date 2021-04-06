using System.Text.RegularExpressions;

public class MountPoint
{
    public Model SourceModel;
    public Regex TypeRegex { get; }
    public Model MountedModel { get; private set; }
    public Coordinate RenderCoordinate { get; }


    public MountPoint(string typeRegex, Coordinate coordinate) : this(null, typeRegex, coordinate)
    {

    }

    public MountPoint(Model sourceModel, string typeRegex, Coordinate coordinate)
    {
        SourceModel = sourceModel;
        TypeRegex = new Regex(typeRegex);
        RenderCoordinate = coordinate;
    }

    public void Mount(Model model)
    {
        if (TypeRegex.IsMatch(model.CommonPropertySet.MountType))
        {
            MountedModel = model;
            model.CommonPropertySet.MountedTo = this;
        }
    }

    public void Unmount()
    {
        MountedModel = null;
    }
}
