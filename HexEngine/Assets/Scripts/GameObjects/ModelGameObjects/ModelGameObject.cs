using UnityEngine;

public class ModelGameObject : MonoBehaviour
{
    public Model Model { get; protected set; }

    public void SetModel(Model model)
    {
        Model = model;
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
