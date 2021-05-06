using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public GameObject ModelLayerGameObject;

    protected static SystemProfile SystemProfile = new SystemProfile();

    //Intervals
    protected MomentumInterval MomentumInterval;
    //Containers
    protected TriggerContainer TriggerContainer;
    protected ModelContainer ModelContainer;
    public static Model SystemModel = new Model(new CommonPropertySet(100, 100, new Coordinate(1000, 1000, 1000), 0, "system", new MomentumPropertySet()), null, null, null);

    // Start is called before the first frame update
    protected void Awake()
    {
        //Intervals init
        MomentumInterval = new MomentumInterval(this);
        //Containers init
        TriggerContainer = new TriggerContainer(this);
        ModelContainer = new ModelContainer(ModelLayerGameObject);
    }

    // Process of battle flow for each turn
    protected void Loop()
    {
        Debug.Log("Turn: " + ++SystemProfile.SystemTick);
        ProcessInterval();
        HandleTrigger();
    }

    private void HandleTrigger()
    {
        Trigger trigger;
        do
        {
            trigger = TriggerContainer.GetTrigger();
            if (trigger != null)
                CheckHook(trigger);
        } while (trigger != null);
    }

    protected void ProcessInterval()
    {
        MomentumInterval.Run(SystemProfile.SystemTick);
    }

    public static int GetSystemTick()
    {
        return SystemProfile.SystemTick;
    }

    public void AddTrigger(Trigger trigger)
    {
        TriggerContainer.AddTrigger(trigger);
    }


    public void SpawnNewModel(Model model)
    {
        ModelContainer.SpawnNewModel(model);
    }

    public Model[] GetModels(Coordinate coordinate = null)
    {
        return ModelContainer.GetModels(coordinate);
    }

    public Model GetModel(Coordinate coordinate = null)
    {
        return ModelContainer.GetModel(coordinate);
    }

    private void CheckHook(Trigger trigger)
    {
        foreach (Model model in ModelContainer.GetModels())
        {
            trigger.Hook(this, model);
        }
    }
}
