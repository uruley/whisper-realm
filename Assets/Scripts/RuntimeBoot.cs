using UnityEngine;

public class RuntimeBoot : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("🟩 RuntimeBoot active — initializing world manually");

        // Main Camera
        GameObject cameraObj = new GameObject("MainCamera");
        Camera cam = cameraObj.AddComponent<Camera>();
        cameraObj.tag = "MainCamera";
        cameraObj.transform.position = new Vector3(0, 5, -10);
        cameraObj.transform.LookAt(Vector3.zero);
        Debug.Log("📷 Camera created");

        // Directional Light
        GameObject lightObj = new GameObject("SceneLight");
        Light light = lightObj.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.2f;
        lightObj.transform.rotation = Quaternion.Euler(50, -30, 0);
        Debug.Log("💡 Light created");

        // Ground
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = Vector3.zero;
        Debug.Log("🪨 Ground created");

        // Ava (Cube)
        GameObject ava = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ava.name = "AvaObject";
        ava.transform.position = new Vector3(0, 1, 0);
        ava.SetActive(true); // Leave her on for now
        Debug.Log("🤖 Ava spawned");
    }
}
