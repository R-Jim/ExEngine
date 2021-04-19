using System.Collections.Generic;
using UnityEngine;

public class ModelContainer
{
    private List<Model> ModelList = new List<Model>();
    private GameObject ModelLayerGameObject;

    public ModelContainer(GameObject modelLayerGameObject)
    {
        ModelLayerGameObject = modelLayerGameObject;
    }

    public bool RemoveModel(Model model)
    {
        if (model.IsRemovable())
        {
            MountPoint mountPoint = model.CommonPropertySet.MountedTo;
            if (mountPoint != null)
            {
                mountPoint.Unmount();
            }
            return true;
        }
        return false;
    }

    public void AddModel(Model model)
    {
        ModelList.Add(model);
    }

    public void SpawnNewModel(Model model)
    {
        GameObject prefab = PrefabPreset.GetPrefab(model.GameObjectPropertySet.PrefabPreset);

        ModelList.Add(model);
        GameObject gameObject = Object.Instantiate(prefab);
        gameObject.transform.parent = ModelLayerGameObject.transform;
        gameObject.GetComponent<ModelGameObject>().SetModel(model);
        Debug.Log("Spawned, " + model.CommonPropertySet.Coordinate.ToString());
    }

    public Model GetModel(Coordinate coordinate)
    {
        Model model = ModelList.Find(m => m.CommonPropertySet.Coordinate.Equals(coordinate));
        return CommonPropertySetUtil.GetUpMostModel(model);
    }

    public Model[] GetModels(Coordinate coordinate = null)
    {
        if (coordinate == null)
        {
            return ModelList.ToArray();
        }
        return ModelList.FindAll(model => model.CommonPropertySet.Coordinate.Equals(coordinate)).ToArray();
    }
}
