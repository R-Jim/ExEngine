using UnityEngine;

public class MoveDebugGO : MonoBehaviour
{
    SystemProfile SystemProfile = new SystemProfile();
    EngineFramework EngineFramework;
    public MomentumStorage.Axis AxisPreset;

    // Start is called before the first frame update
    void Awake()
    {
        SystemProfile.SystemTick = 0;
        SystemProperties.SystemProfile = SystemProfile;
        EngineFramework = new EngineFramework(AxisPreset);
        ModelObserver.ModelList.Add(EngineFramework.AnchorModel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pending: " + PendingEffectObserver.PendingEffectQueue.Count + ", Activated: " + ActivatedEffectObserver.ActivatedEffectQueue.Count);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            EngineFramework.Activate(PendingEffectObserver.PendingEffectQueue);
            Debug.Log("Ignite, " + PendingEffectObserver.PendingEffectQueue.Count);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Next Turn, " + ++SystemProfile.SystemTick);
        }
    }
}
