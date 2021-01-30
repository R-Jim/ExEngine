using UnityEngine;

public class ModelGameObject : MonoBehaviour
{
    public Model Model { get; private set; }
    public bool IsActive;
    public int DebugModelIndex = -1;

    void Start()
    {
        if (DebugModelIndex == -1)
        {
            return;
        }
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
