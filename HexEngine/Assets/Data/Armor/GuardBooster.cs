namespace Assets.Data.Armor
{
    public class GuardBooster : ModelDatatable
    {
        private static readonly string NAME = "Guard Booster";
        private static readonly string DESCRIPTION = "Give 1/sides armor, move 1";
        private static readonly string TYPE = "armor";

        GuardBooster() : base(NAME, DESCRIPTION, TYPE, 10, GetProperties(), null)
        {

        }

        private static DataSet[] GetProperties()
        {
            return new DataSet[] {
                new DataSet(PropertyPreset.Preset.CommonPropertySet, "<in,0/>"),
                new DataSet(PropertyPreset.Preset.GameObjectPropertySet, PrefabPreset.Preset.Alie.ToString()),
                new DataSet(PropertyPreset.Preset.Armor, "1" ), // damge property
                new DataSet(PropertyPreset.Preset.Armor, "1" ),
                new DataSet(PropertyPreset.Preset.Armor, "1" ),
                null,
                null,
                null, // end damge property
            };
        }
    }
}