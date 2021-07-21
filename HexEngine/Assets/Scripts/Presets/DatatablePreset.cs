public class DatatablePreset
{
    public enum Preset
    {
        Alie,
        GuardBooster,
        Blade,
    }

    private static readonly Datatable ALIE = new Alie.Main();
    private static readonly Datatable GUARD_BOOSTER = new Armor.GuardBooster();
    private static readonly Datatable BLADE = new Melee.ShiftBlade();

    public static Datatable GetDatatable(Preset preset)
    {
        switch (preset)
        {
            case Preset.Alie: return ALIE;
            case Preset.GuardBooster: return GUARD_BOOSTER;
            case Preset.Blade: return BLADE;
        };
        return null;
    }
}
