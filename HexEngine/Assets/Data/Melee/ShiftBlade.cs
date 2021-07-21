namespace Melee
{
    public class ShiftBlade : ModelDatatable
    {
        private static readonly string NAME = "Shift Blade";
        private static readonly string DESCRIPTION = "Deal damage on 1/half sides";
        private static readonly string TYPE = "melee";

        public ShiftBlade() : base(NAME, DESCRIPTION, TYPE, 10, GetProperties(), null)
        {

        }

        private static DataSet[] GetProperties()
        {
            return new DataSet[] {
                new DataSet(PropertyPreset.Preset.CommonPropertySet, "<in,0/>"),
                new DataSet(PropertyPreset.Preset.GameObjectPropertySet, PrefabPreset.Preset.Alie.ToString()),
                new DataSet(PropertyPreset.Preset.Damage, "1" ), // damge property
                new DataSet(PropertyPreset.Preset.Damage, "1" ),
                new DataSet(PropertyPreset.Preset.Damage, "1" ),
                null,
                null,
                null, // end damge property
            };
        }
    }
}