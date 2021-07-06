namespace Assets.Data.Alie
{
    public class Main : ModelDatatable
    {
        private static readonly string NAME = "Alie";
        private static readonly string DESCRIPTION = "Sell swords";
        private static readonly string TYPE = "human";

        Main() : base(NAME, DESCRIPTION, TYPE, 10, GetProperties(), null)
        {

        }

        private static DataSet[] GetProperties()
        {
            return new DataSet[] {
                new DataSet(PropertyPreset.Preset.CommonPropertySet, "<in,0/>"),
                new DataSet(PropertyPreset.Preset.GameObjectPropertySet, PrefabPreset.Preset.Alie.ToString()),
                null, // damge property
                null,
                null,
                null,
                null,
                null, // end damge property
                new DataSet(PropertyPreset.Preset.Coordinate, "0.0", "0.0", "0.0"),
                new DataSet(PropertyPreset.Preset.Coordinate, "0.0", "0.0", "0.0"),
                new DataSet(PropertyPreset.Preset.Mount, "armor", "<prop,7>" ),
                new DataSet(PropertyPreset.Preset.Mount, "weapon", "<prop,8>"),
            };
        }
    }
}