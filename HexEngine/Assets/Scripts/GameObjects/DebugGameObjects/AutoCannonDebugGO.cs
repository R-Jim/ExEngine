using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonDebugGO : MonoBehaviour
{
    SystemProfile SystemProfile = new SystemProfile();
    Model AutoCannon;
    public Coordinate.Axis FiringAxisPreset;
    public int Ammo = 5;
    public int ProjectileRange = 5;
    public int TargetSpacing = 2;
    IEnumerator SystemTickCoroutine;
    readonly CannonDatatable CannonDatatable = new CannonDatatable();
    readonly Coordinate Coordinate = new Coordinate(0, 0, 0);

    // Start is called before the first frame update
    void Awake()
    {
        SystemProfile.SystemTick = 0;
        SystemProperties.SystemProfile = SystemProfile;

        CannonDatatable.Init(new object[] { Coordinate });
        AutoCannon = (Model)CannonDatatable.MainProperty();
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
            List<Effect> effects = CannonDatatable.GetEffectListByAction(1, new object[] { CoordinateUtil.GetCoordinate(FiringAxisPreset) });
            PendingEffectObserver.PendingEffectQueue.Enqueue(effects[0]);
            Debug.Log("Bang, " + PendingEffectObserver.PendingEffectQueue.Count + " Ammo, " + (((Storage)AutoCannon).Current - 1));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Coordinate destroyableCoordinate = CoordinateUtil.GetCoordinate(FiringAxisPreset, TargetSpacing);
            PendingEffectObserver.PendingEffectQueue.Enqueue(GetSpawnDetroyableModel(destroyableCoordinate));
            Debug.Log("Spawn, " + destroyableCoordinate.ToString());
        }
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

    //private Effect GetChainSpawnProjectileEffect()
    //{
    //    Projectile projectile = GetProjectileModel();

    //    return GetSpawnProjectileEffect(projectile);
    //}

    //private Effect GetSpawnProjectileEffect(Projectile projectile)
    //{
    //    SpawnEffect spawnEffect = new SpawnEffect(AutoCannon, new Coordinate(0, 0, 0), projectile);
    //    ChainEffect chainEffect = new ChainEffect(AutoCannon, spawnEffect, GetProjectTileRepeatMoveEffect(projectile),
    //        Effect.EffectStatus.Activated);

    //    RequestEffect requestEffect = new RequestEffect(AutoCannon, AutoCannon, 1, chainEffect);
    //    return requestEffect;
    //}

    //private Effect GetProjectTileRepeatMoveEffect(Projectile projectile)
    //{
    //    MomentumRepeater momentumRepeater = new MomentumRepeater(projectile.MomentumStorage);
    //    RepeatEffect.RepeaterProperties repeaterProperties = new RepeatEffect.RepeaterProperties(1, 1, 1);

    //    MoveEffect moveEffect = new MoveEffect(projectile, projectile, CoordinateUtil.GetCoordinate(FiringAxisPreset));
    //    CollisionEffect collisionEffect = new CollisionEffect(projectile, projectile.CommonPropertySet.Coordinate);

    //    ChainEffect chainEffect = new ChainEffect(projectile, collisionEffect, moveEffect.Clone(), Effect.EffectStatus.Pending);

    //    RepeatEffect repeatEffect = new RepeatEffect(projectile, momentumRepeater, repeaterProperties, chainEffect);

    //    return new ChainEffect(projectile, moveEffect, repeatEffect, Effect.EffectStatus.Activated);
    //}

    //private Projectile GetProjectileModel()
    //{
    //    MomentumStorage momentumStorage = new MomentumStorage(FiringAxisPreset, ProjectileRange, null);
    //    Projectile projectile = new Projectile(momentumStorage, new CommonPropertySet(10, new Coordinate(0, 0, 0)));
    //    return projectile;
    //}

    private SpawnEffect GetSpawnDetroyableModel(Coordinate coordinate)
    {
        Model destroyableModel = new Model(new CommonPropertySet(10, coordinate), new GameObjectPropertySet(PrefabPreset.Preset.Placeholder));
        return new SpawnEffect(null, destroyableModel, 0);
    }
}
