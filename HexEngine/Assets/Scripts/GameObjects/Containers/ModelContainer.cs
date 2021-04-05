using System.Collections.Generic;
using UnityEngine;

public class ModelContainer : MonoBehaviour
{
    public static List<Model> ModelList = new List<Model>();
    //Prefab
    public GameObject ProjectileModelPrefab;
    public GameObject PlaceholderModelPrefab;
    public GameObject DummyModelPrefab;

    //Prefab usage
    public static GameObject ProjectilePrefab;
    public static GameObject PlaceholderPrefab;
    public static GameObject DummyPrefab;

    public static GameObject ModelLayer;
    public GameObject ModelLayerGameObject;


    void Start()
    {
        ProjectilePrefab = ProjectileModelPrefab;
        PlaceholderPrefab = PlaceholderModelPrefab;
        DummyPrefab = DummyModelPrefab;
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
        GameObject prefab = PrefabPreset.GetPrefab(model.GameObjectPropertySet.PrefabPreset);

        ModelList.Add(model);
        GameObject projectile = Instantiate(prefab);
        projectile.transform.parent = ModelLayer.transform;
        projectile.GetComponent<ModelGameObject>().SetModel(model);
        Debug.Log("Spawned, " + model.CommonPropertySet.Coordinate.ToString());
    }

    public static Model GetModel(Coordinate coordinate)
    {
        Model model = ModelList.Find(m => m.CommonPropertySet.Coordinate.Equals(coordinate));
        return CommonPropertySetUtil.GetUpMostModel(model);
    }

    public static List<Model> GetModelList(Coordinate coordinate)
    {
        return ModelList.FindAll(model => model.CommonPropertySet.Coordinate.Equals(coordinate));
    }
}
