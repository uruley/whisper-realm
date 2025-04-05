using UnityEngine;

public class RuntimeBoot : MonoBehaviour
{
    void Awake()
    {
        GameObject loader = new GameObject("RealmLoader");
        loader.AddComponent<SceneInitializer>();
    }
}

