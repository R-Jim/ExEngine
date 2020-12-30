﻿using System.Collections;
using UnityEngine;

public class AutoCannonDebugGO : MonoBehaviour
{
    SystemProfile SystemProfile = new SystemProfile();
    MomentumStorage AutoCannon;
    public MomentumStorage.Axis FiringAxisPreset;
    public int Ammo = 5;
    IEnumerator SystemTickCoroutine;

    // Start is called before the first frame update
    void Awake()
    {
        SystemProfile.SystemTick = 0;
        Systemproperties.SystemProfile = SystemProfile;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Ammo, " + AutoCannon.Current);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            PendingEffectObserver.PendingEffectQueue.Enqueue(GetChainSpawnProjectileEffect());
            Debug.Log("Bang, " + PendingEffectObserver.PendingEffectQueue.Count);
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
        Model projectile = GetProjectileModel();

        ChainEffect chainEffect = new ChainEffect(AutoCannon, GetSpawnProjectileEffect(projectile), GetProjectTileRepeatMoveEffect(projectile), Effect.EffectStatus.Activated);
        return chainEffect;
    }

    private Effect GetSpawnProjectileEffect(Model projectile)
    {
        SpawnEffect spawnEffect = new SpawnEffect(AutoCannon, new Coordinate(0, 0, 0), projectile);
        RequestEffect requestEffect = new RequestEffect(AutoCannon, AutoCannon, 1, spawnEffect);
        return requestEffect;
    }

    private Effect GetProjectTileRepeatMoveEffect(Model projectile)
    {
        MomentumStorage momentumStorage = new MomentumStorage(FiringAxisPreset, 5);
        MomentumRepeater momentumRepeater = new MomentumRepeater(momentumStorage);
        RepeatEffect.RepeaterProperties repeaterProperties = new RepeatEffect.RepeaterProperties(1, 1, 1);
        MoveEffect moveEffect = new MoveEffect(null, projectile.CommonPropertySet.Coordinate, CoordinateUtil.GetCoordinate(FiringAxisPreset));

        RepeatEffect repeatEffect = new RepeatEffect(null, momentumRepeater, repeaterProperties, moveEffect);
        return repeatEffect;
    }

    private Model GetProjectileModel()
    {
        return new Model(new CommonPropertySet(10, CoordinateUtil.GetCoordinate(FiringAxisPreset)));
    }
}