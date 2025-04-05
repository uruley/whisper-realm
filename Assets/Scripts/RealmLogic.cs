using UnityEngine;

public class RealmLogic : MonoBehaviour
{
    private float checkInterval = 5f;
    private float timer = 0f;
    private int lastSparkCount = 0;
    private Light sceneLight;

    void Start()
    {
        Debug.Log("🌍 RealmLogic initialized.");

        // Find the directional light in the scene
        sceneLight = GameObject.FindObjectOfType<Light>();

        if (sceneLight == null)
        {
            Debug.LogWarning("⚠️ No light found in scene. Spark reactions will not be visible.");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            timer = 0f;

            int sparkCount = SparkSystem.sparkLog.Count;

            if (sparkCount > lastSparkCount)
            {
                int newCount = sparkCount - lastSparkCount;
                lastSparkCount = sparkCount;

                string latest = SparkSystem.sparkLog[sparkCount - 1];
                Debug.Log($"⚡ New Spark Detected: {latest}");

                ReactToSpark(latest.ToLower());
            }
        }
    }

    void ReactToSpark(string spark)
    {
        if (sceneLight == null) return;

        if (spark.Contains("dark"))
        {
            sceneLight.intensity = 0.2f;
            Debug.Log("🌓 Realm darkens.");
        }
        else if (spark.Contains("light"))
        {
            sceneLight.intensity = 1.5f;
            Debug.Log("☀️ Realm brightens.");
        }
        else if (spark.Contains("fog"))
        {
            RenderSettings.fog = true;
            Debug.Log("🌫 Fog rises in the Realm.");
        }
        else if (spark.Contains("clear") || spark.Contains("sun"))
        {
            RenderSettings.fog = false;
            sceneLight.intensity = 1.0f;
            Debug.Log("🌤 The fog clears, sunlight returns.");
        }
        else
        {
            Debug.Log("🌀 Spark detected, but no visual effect assigned.");
        }
    }
}
