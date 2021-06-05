public class EnergyStorageDatatable : Datatable
{
    public EnergyStorageDatatable() : base(GetProperties())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            GetEnergyStorage(),
        };
    }


    private static DataSet GetEnergyStorage()
    {
        string energyLimit = "3";
        string hp = "1";
        string weight = "1";
        return new DataSet(ModelPreset.Preset.Storage, new string[] {
            energyLimit,
            hp,
            hp,
            "<in,0/>",
            weight,
            "energy_storage",
            "0",
            "0",
            "0",
            "<prop,1/>",
            "1", //TODO: change to Blade prefab
        });
    }
}
