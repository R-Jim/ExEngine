using UnityEngine;

public class ModelGameObject : MonoBehaviour
{
    public Model Model { get; private set; }
    public bool IsActive;
    public int DebugModelIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (DebugModelIndex == -1)
        {
            return;
        }
        //Get the placeholder model for debug/design
        SetModel(ModelContainer.ModelList[DebugModelIndex]);
    }

    public void SetModel(Model model)
    {
        Model = model;
        IsActive = true;
        AnimationGameObject animationGameObject = gameObject.GetComponent<AnimationGameObject>();
        if (animationGameObject != null)
        {
            animationGameObject.Model = model;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Model == null)
        {
            return;
        }
        if (Model.IsRemovable())
        {
            Destroy(gameObject);
        }
    }
}
