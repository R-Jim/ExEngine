using System.Collections.Generic;
using UnityEngine;

public class AutoCannonDebugGO : MonoBehaviour
{
    Model AutoCannon;
    public Coordinate.Vector FiringVectorDirectionPreset;
    public int Ammo = 5;
    public int TargetSpacing = 2;
    readonly CannonDatatable CannonDatatable = new CannonDatatable();
    readonly Coordinate Coordinate = new Coordinate(1, 1, 0);

    // Start is called before the first frame update
    void Awake()
    {
        ModelContainer.ModelList.Add(new Model(new CommonPropertySet(100, new Coordinate(1000, 1000, 1000), "system"), null, null));

        //Init mount model
        MountPoint weaponMountPoint = new MountPoint("weapon", new Coordinate(0, 0.03f, 0));
        Model MountPlaceholderModel = new Model(new CommonPropertySet(100, Coordinate.Clone()), null, new MountPoint[] { weaponMountPoint });
        ModelContainer.ModelList.Add(MountPlaceholderModel);

        //Init Auto cannon model
        CannonDatatable.Init(new object[] { Coordinate.Clone() });
        AutoCannon = (Model)CannonDatatable.MainProperty();

        weaponMountPoint.Mount(AutoCannon);

        ModelContainer.ModelList.Add(AutoCannon);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<Trigger> triggerList = CannonDatatable.GetTriggerListByAction(1, new object[] { CoordinateUtil.GetCoordinate(FiringVectorDirectionPreset) });
            TriggerContainer.QueueTrigger(triggerList[0]);
            Debug.Log("Bang, " + TriggerContainer.TriggerQueue.Count + " Ammo, " + (((StorageModel)AutoCannon).StoragePropertySet.Current - 1));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            List<Trigger> triggerList = CannonDatatable.GetTriggerListByAction(2, new object[] { CoordinateUtil.GetCoordinate(FiringVectorDirectionPreset) });
            TriggerContainer.QueueTrigger(triggerList[0]);
        }
        //else if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Coordinate destroyableCoordinate = CoordinateUtil.GetCoordinate(FiringAxisPreset, TargetSpacing);
        //    TriggerObserver.TriggerQueue.Enqueue(GetSpawnDetroyableModel(destroyableCoordinate));
        //    Debug.Log("Spawn, " + destroyableCoordinate.ToString());
        //}
        //else if (Input.GetKeyDown(KeyCode.R))
        //{
        //    AutoCannon.Fill(Ammo);
        //    Debug.Log("Reload, " + AutoCannon.Current);
        //}
        if (Input.GetKeyDown(KeyCode.P))
        {
            SystemProperties.IsSwitch = true;
        }
    }

    //private SpawnEffect GetSpawnDetroyableModel(Coordinate coordinate)
    //{
    //    Model destroyableModel = new Model(new CommonPropertySet(10, coordinate), new GameObjectPropertySet(PrefabPreset.Preset.Placeholder));
    //    return new SpawnEffect(null, destroyableModel, 0);
    //}
}
