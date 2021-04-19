using UnityEngine;

public class DebugModelGameObject : ModelGameObject
{
    public int DebugModelIndex = -1;
    private BattleHandler BattleHandler;
    public GameObject SystemGameObject;

    void Start()
    {
        BattleHandler = SystemGameObject.GetComponent<BattleHandler>();

        if (DebugModelIndex == -1)
        {
            return;
        }
        SetModel(BattleHandler.GetModels()[DebugModelIndex]);
    }
}
