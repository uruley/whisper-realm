using UnityEngine;

public class RealmTemplate : MonoBehaviour
{
    void Start()
    {
        // ✅ CAMERA
        GameObject cam = new GameObject("MainCamera");
        Camera camera = cam.AddComponent<Camera>();
        cam.tag = "MainCamera";
        cam.transform.position = new Vector3(0, 5, -10);
        cam.transform.LookAt(Vector3.zero);

        // ✅ LIGHTING
        GameObject light = new GameObject("Directional Light");
        Light dirLight = light.AddComponent<Light>();
        dirLight.type = LightType.Directional;
        dirLight.intensity = 1.2f;
        light.transform.rotation = Quaternion.Euler(50, -30, 0);

        // ✅ GROUND
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = Vector3.zero;

        // ✅ REALM MANAGER HOOK
        GameObject manager = new GameObject("RealmManager");
        manager.AddComponent<RealmLogic>();

        // ✅ AVA (CUBE) + LISTENER
        GameObject ava = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ava.name = "AvaObject";
        ava.transform.position = new Vector3(0, 1, 0);
        ava.SetActive(false); // Starts hidden

        GameObject avaManager = new GameObject("AvaManager");
        AvaCommandListener listener = avaManager.AddComponent<AvaCommandListener>();
        listener.AvaObject = ava;
    }
}
