using System.Collections;
using UnityEngine;

public class AutoCannonDebugGO : MonoBehaviour
{
    SystemProfile SystemProfile = new SystemProfile();
    MomentumStorage AutoCannon;
    public MomentumStorage.Axis FiringAxisPreset;
    public int Ammo = 5;
    public int ProjectileRange = 5;
    public int TargetSpacing = 2;
    IEnumerator SystemTickCoroutine;

    // Start is called before the first frame update
    void Awake()
    {
        SystemProfile.SystemTick = 0;
        SystemProperties.SystemProfile = SystemProfile;
        AutoCannon = new MomentumStorage(FiringAxisPreset, Ammo, new CommonPropertySet(100, new Coordinate(0, 0, 0)));
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
            PendingEffectObserver.PendingEffectQueue.Enqueue(GetChainSpawnProjectileEffect());
            Debug.Log("Bang, " + PendingEffectObserver.PendingEffectQueue.Count + " Ammo, " + (AutoCannon.Current - 1));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Coordinate destroyableCoordinate = CoordinateUtil.GetCoordinate(FiringAxisPreset, TargetSpacing);
            PendingEffectObserver.PendingEffectQueue.Enqueue(GetSpawnDetroyableModel(destroyableCoordinate));
            Debug.Log("Spawn, " + destroyableCoordinate.ToString());
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            AutoCannon.Fill(Ammo);
            Debug.Log("Reload, " + AutoCannon.Current);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
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

    private Effect GetChainSpawnProjectileEffect()
    {
        Projectile projectile = GetProjectileModel();

        return GetSpawnProjectileEffect(projectile);
    }

    private Effect GetSpawnProjectileEffect(Projectile projectile)
    {
        SpawnEffect spawnEffect = new SpawnEffect(AutoCannon, new Coordinate(0, 0, 0), projectile);
        ChainEffect chainEffect = new ChainEffect(AutoCannon, spawnEffect, GetProjectTileRepeatMoveEffect(projectile),
            Effect.EffectStatus.Activated);

        RequestEffect requestEffect = new RequestEffect(AutoCannon, AutoCannon, 1, chainEffect);
        return requestEffect;
    }

    private Effect GetProjectTileRepeatMoveEffect(Projectile projectile)
    {
        MomentumRepeater momentumRepeater = new MomentumRepeater(projectile.MomentumStorage);
        RepeatEffect.RepeaterProperties repeaterProperties = new RepeatEffect.RepeaterProperties(1, 1, 1);

        MoveEffect moveEffect = new MoveEffect(projectile, projectile, CoordinateUtil.GetCoordinate(FiringAxisPreset));
        CollisionEffect collisionEffect = new CollisionEffect(projectile, projectile.CommonPropertySet.Coordinate);

        ChainEffect chainEffect = new ChainEffect(projectile, collisionEffect, moveEffect.Clone(), Effect.EffectStatus.Pending);

        RepeatEffect repeatEffect = new RepeatEffect(projectile, momentumRepeater, repeaterProperties, chainEffect);

        return new ChainEffect(projectile, moveEffect, repeatEffect, Effect.EffectStatus.Activated);
    }

    private Projectile GetProjectileModel()
    {
        MomentumStorage momentumStorage = new MomentumStorage(FiringAxisPreset, ProjectileRange, null);
        Projectile projectile = new Projectile(momentumStorage, new CommonPropertySet(10, new Coordinate(0, 0, 0)));
        return projectile;
    }

    private SpawnEffect GetSpawnDetroyableModel(Coordinate coordinate)
    {
        Model destroyableModel = new Model(new CommonPropertySet(10, coordinate));
        return new SpawnEffect(null, coordinate, destroyableModel);
    }
}
