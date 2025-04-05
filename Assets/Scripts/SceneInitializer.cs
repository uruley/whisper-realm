using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    void Start()
    {
        // Load the Realm system
        GameObject realmRoot = new GameObject("Realm");
        realmRoot.AddComponent<RealmTemplate>();
    }
}
