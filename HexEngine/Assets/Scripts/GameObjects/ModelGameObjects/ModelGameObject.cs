using UnityEngine;

public class ModelGameObject : MonoBehaviour
{
    public Model Model;
    public int DebugModelIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (DebugModelIndex == -1)
        {
            return;
        }
        //Get the placeholder model for debug/design
        Model = ModelObserver.ModelList[DebugModelIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Model.IsRemovable())
        {
            Destroy(gameObject);
        }
    }
}
