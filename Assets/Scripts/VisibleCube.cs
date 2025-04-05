
using UnityEngine;

public class VisibleCube : MonoBehaviour
{
    void Start()
    {
        Debug.Log("🟥 VisibleCube script running...");

        GameObject camObj = new GameObject("MainCamera");
        Camera cam = camObj.AddComponent<Camera>();
        camObj.tag = "MainCamera";
        camObj.transform.position = new Vector3(0, 5, -10);
        camObj.transform.LookAt(Vector3.zero);

        GameObject lightObj = new GameObject("SceneLight");
        Light light = lightObj.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.2f;
        lightObj.transform.rotation = Quaternion.Euler(50, -30, 0);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 1, 0);
        cube.name = "TestCube";
        Debug.Log("🟥 Cube created.");
    }
}
