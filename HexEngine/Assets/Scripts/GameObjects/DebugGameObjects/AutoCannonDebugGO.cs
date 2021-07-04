using System.Collections.Generic;
using UnityEngine;

public class AutoCannonDebugGO : BattleHandler
{
    //Model AutoCannon;
    //public Coordinate.Vector FiringVectorDirectionPreset;
    //public int Ammo = 5;
    //public int TargetSpacing = 2;
    //readonly CannonDatatable CannonDatatable = new CannonDatatable();
    //private Host Cannon;
    //readonly Coordinate Coordinate = new Coordinate(1, 1, 0);

    //new void Awake()
    //{
    //    base.Awake();

    //    ModelContainer.AddModel(SystemModel);

    //    //Init mount model
    //    MountPoint weaponMountPoint = new MountPoint("weapon", new Coordinate(0, 0.03f, 0));
    //    Model MountPlaceholderModel = new Model(new CommonPropertySet(100, 100, Coordinate.Clone(), 20, null, new MomentumPropertySet()), null, null, new MountPoint[] { weaponMountPoint });
    //    ModelContainer.AddModel(MountPlaceholderModel);

    //    //Init Auto cannon model
    //    Cannon = new Host(CannonDatatable, new object[] { Coordinate.Clone() });
    //    AutoCannon = Cannon.Model;

    //    weaponMountPoint.Mount(AutoCannon);

    //    ModelContainer.AddModel(AutoCannon);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Coordinate spawnCoordinate = AutoCannon.CommonPropertySet.Coordinate.Clone();
    //        spawnCoordinate.Add(CoordinateUtil.GetCoordinate(FiringVectorDirectionPreset));
    //        // new object[] { spawnCoordinate, FiringVectorDirectionPreset }
    //        List<Trigger> triggerList = Cannon.GetTriggerListByAction(1);
    //        TriggerContainer.AddTrigger(triggerList[0]);
    //        Debug.Log("Bang: Ammo, " + (((StorageModel)AutoCannon).StoragePropertySet.Current - 1));
    //    }
    //    if (Input.GetKeyDown(KeyCode.LeftControl))
    //    {
    //        Coordinate spawnCoordinate = AutoCannon.CommonPropertySet.Coordinate.Clone();
    //        spawnCoordinate.Add(CoordinateUtil.GetCoordinate(FiringVectorDirectionPreset));
    //        List<Trigger> triggerList = Cannon.GetTriggerListByAction(3);
    //        TriggerContainer.AddTrigger(triggerList[0]);
    //        Debug.Log("Bang: High impact Ammo, " + (((StorageModel)AutoCannon).StoragePropertySet.Current - 1));
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        Coordinate spawnCoordinate = AutoCannon.CommonPropertySet.Coordinate.Clone();
    //        spawnCoordinate.Add(CoordinateUtil.GetCoordinate(FiringVectorDirectionPreset));
    //        List<Trigger> triggerList = Cannon.GetTriggerListByAction(4);
    //        TriggerContainer.AddTrigger(triggerList[0]);
    //        Debug.Log("Spawn Dummy");
    //    }
    //    if (Input.GetKeyDown(KeyCode.M))
    //    {
    //        //, new object[] { FiringVectorDirectionPreset }
    //        List<Trigger> triggerList = Cannon.GetTriggerListByAction(2);
    //        TriggerContainer.AddTrigger(triggerList[0]);
    //    }
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        Loop();
    //    }
    //}
}
