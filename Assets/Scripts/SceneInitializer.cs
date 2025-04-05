
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    void Start()
    {
        // ✅ CAMERA
        GameObject cameraObj = new GameObject("MainCamera");
        Camera cam = cameraObj.AddComponent<Camera>();
        cameraObj.tag = "MainCamera";
        cameraObj.transform.position = new Vector3(0, 5, -10);
        cameraObj.transform.LookAt(Vector3.zero);

        // ✅ LIGHTING
        GameObject lightObj = new GameObject("Directional Light");
        Light light = lightObj.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.2f;
        lightObj.transform.rotation = Quaternion.Euler(50, -30, 0);

        // ✅ GROUND
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = Vector3.zero;

        // ✅ AVA CUBE
        GameObject ava = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ava.name = "AvaObject";
        ava.transform.position = new Vector3(0, 1, 0);
        ava.SetActive(false); // Starts hidden

        // ✅ AVA MANAGER
        GameObject manager = new GameObject("AvaManager");
        AvaCommandListener listener = manager.AddComponent<AvaCommandListener>();
        listener.AvaObject = ava;
    }
}
