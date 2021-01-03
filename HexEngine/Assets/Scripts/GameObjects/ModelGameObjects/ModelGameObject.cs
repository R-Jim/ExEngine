using UnityEngine;

public class ModelGameObject : MonoBehaviour
{
    public Model Model { get; private set; }
    public int DebugModelIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (DebugModelIndex == -1)
        {
            return;
        }
        //Get the placeholder model for debug/design
        SetModel(ModelObserver.ModelList[DebugModelIndex]);
    }

    public void SetModel(Model model)
    {
        Model = model;
        AnimationGameObject animationGameObject = gameObject.GetComponent<AnimationGameObject>();
        if (animationGameObject != null)
        {
            animationGameObject.Model = model;
        }
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
