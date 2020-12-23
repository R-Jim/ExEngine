using UnityEngine;

public class DebugGO : MonoBehaviour
{
    SystemProfile SystemProfile = new SystemProfile();
    EngineFramework EngineFramework;

    // Start is called before the first frame update
    void Start()
    {
        SystemProfile.SystemTick = 0;
        Systemproperties.SystemProfile = SystemProfile;
        EngineFramework = new EngineFramework();
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
            EngineFramework.Ignite();
            Debug.Log("Ignite, " + PendingEffectObserver.PendingEffectQueue.Count);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Next Turn, " + ++SystemProfile.SystemTick);
        }
    }
}
