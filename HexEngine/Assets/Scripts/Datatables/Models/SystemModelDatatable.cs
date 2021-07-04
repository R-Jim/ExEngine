public class SystemModelDatatable : ModelDatatable
{
    //Pause, etc properties

    public SystemModelDatatable() : base(null, null, null, 0, null, null)
    {
    }

    public new Model GetModel()
    {
        return new Model(null, null, null);
    }
}
