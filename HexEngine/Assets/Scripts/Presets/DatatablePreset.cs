public class DatatablePreset
{
    public enum Preset
    {
        Cannon,
        HighImpactBullet,
        Bullet,
        FiringBullet,
        Dummy,
    }

    public static Datatable GetDatatable(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Cannon: return new CannonDatatable();
            case Preset.HighImpactBullet: return new HighImpactBulletDatatable();
            case Preset.Bullet: return new BulletDatatable();
            case Preset.FiringBullet: return new FiringBulletDatatable();
            case Preset.Dummy: return new DummyDatatable();
        };
        return null;
    }
}
