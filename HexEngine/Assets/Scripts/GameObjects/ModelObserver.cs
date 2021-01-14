using System.Collections.Generic;
using UnityEngine;

public class ModelObserver : MonoBehaviour
{
    public static List<Model> ModelList = new List<Model>();
    public GameObject ProjectileModelPrefab;
    public GameObject PlaceholderModelPrefab;
    public GameObject ModelLayerGameObject;
    public static GameObject ProjectilePrefab;
    public static GameObject PlaceholderPrefab;
    public static GameObject ModelLayer;

    void Start()
    {
        ProjectilePrefab = ProjectileModelPrefab;
        PlaceholderPrefab = PlaceholderModelPrefab;
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
        GameObject prefab = model.GameObjectPropertySet.PrefabPreset == PrefabPreset.Preset.Projectile ? ProjectilePrefab : PlaceholderPrefab;

        ModelList.Add(model);
        GameObject projectile = Instantiate(prefab);
        projectile.transform.parent = ModelLayer.transform;
        projectile.GetComponent<ModelGameObject>().SetModel(model);
        Debug.Log("Spawned, " + model.CommonPropertySet.Coordinate.ToString());
    }
}
