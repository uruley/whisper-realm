using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    void Start()
    {
        GameObject cam = new GameObject("MainCamera");
        cam.AddComponent<Camera>();
        cam.transform.position = new Vector3(0, 5, -10);
        cam.transform.LookAt(Vector3.zero);

        GameObject light = new GameObject("Directional Light");
        Light dirLight = light.AddComponent<Light>();
        dirLight.type = LightType.Directional;
        dirLight.intensity = 1.2f;
        light.transform.rotation = Quaternion.Euler(50, -30, 0);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "VisibleCube";
        cube.transform.position = new Vector3(0, 1, 0);
    }
}
