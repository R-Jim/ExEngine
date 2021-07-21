namespace Action
{
    public class Move : Datatable
    {
        public Move() : base(GetProperties())
        {

        }

        private static DataSet[] GetProperties()
        {
            // act:0- storage unit, act:1- consumer
            return new DataSet[] {
            new DataSet(TriggerPreset.Preset.Request, "<action,0/>", "1", "<prop,1/>" , "1"),
            new DataSet(EffectPreset.Preset.Modifier, "2", "<action,1/>", "1" ),
        };
        }
    }
}
