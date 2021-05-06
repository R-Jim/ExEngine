using UnityEngine;

public class ModelGameObject : MonoBehaviour
{
    public Model Model { get; protected set; }

    public void SetModel(Model model)
    {
        Model = model;
        AnimationGameObject animationGameObject = GetComponent<AnimationGameObject>();
        if (animationGameObject != null)
        {
            animationGameObject.Model = model;
        }
        MovemonentMapper movemonentMapper = GetComponent<MovemonentMapper>();
        if (movemonentMapper != null)
        {
            movemonentMapper.Model = model;
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
