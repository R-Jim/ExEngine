using UnityEngine;

public class PrefabGameObjectPreset : MonoBehaviour
{
    public GameObject ProjectileModelPrefab;
    public GameObject PlaceholderModelPrefab;
    public GameObject DummyModelPrefab;

    //Prefab usage
    public static GameObject ProjectilePrefab;
    public static GameObject PlaceholderPrefab;
    public static GameObject DummyPrefab;


    void Start()
    {
        ProjectilePrefab = ProjectileModelPrefab;
        PlaceholderPrefab = PlaceholderModelPrefab;
        DummyPrefab = DummyModelPrefab;
    }
}
