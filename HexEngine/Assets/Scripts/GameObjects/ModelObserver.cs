using System.Collections.Generic;
using UnityEngine;

public class ModelObserver : MonoBehaviour
{
    public static List<Model> ModelList = new List<Model>();
    public GameObject ProjectilePrefab;
    public GameObject ModelLayerGameObject;
    public static GameObject Prefab;
    public static GameObject ModelLayer;

    void Start()
    {
        Prefab = ProjectilePrefab;
        ModelLayer = ModelLayerGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RemoveModel();
    }

    private void RemoveModel()
    {
        ModelList.RemoveAll(Model => Model.IsRemovable());
    }

    public static void SpawnNewModel(Model model)
    {
        ModelList.Add(model);
        GameObject projectile = Instantiate(Prefab);
        projectile.transform.parent = ModelLayer.transform;
        projectile.GetComponent<ModelGameObject>().Model = model;
        Debug.Log("Spawned, " + model.CommonPropertySet.Coordinate.ToString());
    }
}
