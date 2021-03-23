public class DatatablePreset
{
    public enum Preset
    {
        Cannon,
        Bullet,
        FiringBullet,
    }

    public static Datatable GetDatatable(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Cannon: return new CannonDatatable();
            case Preset.Bullet: return new BulletDatatable();
            case Preset.FiringBullet: return new FiringBulletDatatable();
        };
        return null;
    }
}
