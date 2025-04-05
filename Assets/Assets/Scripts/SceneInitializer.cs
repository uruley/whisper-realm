
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    void Start()
    {
        // 🔷 Create a simple cube as Ava's placeholder
        GameObject ava = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ava.name = "AvaObject";
        ava.transform.position = new Vector3(0, 1, 0);
        ava.SetActive(false); // Start hidden

        // 🔶 Create a manager and attach the listener script
        GameObject manager = new GameObject("AvaManager");
        AvaCommandListener listener = manager.AddComponent<AvaCommandListener>();
        listener.AvaObject = ava;
    }
}
