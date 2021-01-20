using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonDebugGO : MonoBehaviour
{
    SystemProfile SystemProfile = new SystemProfile();
    Model AutoCannon;
    public Coordinate.Axis FiringAxisPreset;
    public int Ammo = 5;
    public int TargetSpacing = 2;
    IEnumerator SystemTickCoroutine;
    readonly CannonDatatable CannonDatatable = new CannonDatatable();
    readonly Coordinate Coordinate = new Coordinate(1, 1, 0);

    // Start is called before the first frame update
    void Awake()
    {
        SystemProfile.SystemTick = 0;
        SystemProperties.SystemProfile = SystemProfile;
        ModelObserver.ModelList.Add(new Model(new CommonPropertySet(100, Coordinate.Clone(), "system"), null, null));

        //Init mount model
        MountPoint weaponMountPoint = new MountPoint("weapon", new Coordinate(0, 0.03f, 0));
        Model MountPlaceholderModel = new Model(new CommonPropertySet(100, Coordinate.Clone()), null, new MountPoint[] { weaponMountPoint });
        ModelObserver.ModelList.Add(MountPlaceholderModel);

        //Init Auto cannon model
        CannonDatatable.Init(new object[] { Coordinate.Clone() });
        AutoCannon = (Model)CannonDatatable.MainProperty();

        weaponMountPoint.Mount(AutoCannon);

        ModelObserver.ModelList.Add(AutoCannon);
    }

    void Start()
    {
        SystemTickCoroutine = SystemTick();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<Trigger> triggerList = CannonDatatable.GetTriggerListByAction(1, new object[] { CoordinateUtil.GetCoordinate(FiringAxisPreset) });
            TriggerObserver.QueueTrigger(triggerList[0]);
            Debug.Log("Bang, " + TriggerObserver.TriggerQueue.Count + " Ammo, " + (((Storage)AutoCannon).Current - 1));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            List<Trigger> triggerList = CannonDatatable.GetTriggerListByAction(2, new object[] { CoordinateUtil.GetCoordinate(FiringAxisPreset) });
            TriggerObserver.QueueTrigger(triggerList[0]);
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Next Turn, " + ++SystemProfile.SystemTick);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Continue, " + SystemProfile.SystemTick);
            StartCoroutine(SystemTickCoroutine);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Pause," + SystemProfile.SystemTick);
            StopCoroutine(SystemTickCoroutine);
        }
    }

    IEnumerator SystemTick()
    {
        while (true)
        {
            ++SystemProfile.SystemTick;
            yield return new WaitForSeconds(.5f);
        }
    }

    //private SpawnEffect GetSpawnDetroyableModel(Coordinate coordinate)
    //{
    //    Model destroyableModel = new Model(new CommonPropertySet(10, coordinate), new GameObjectPropertySet(PrefabPreset.Preset.Placeholder));
    //    return new SpawnEffect(null, destroyableModel, 0);
    //}
}
