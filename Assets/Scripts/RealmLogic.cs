using UnityEngine;

public class RealmLogic : MonoBehaviour
{
    private float checkInterval = 5f;
    private float timer = 0f;
    private int lastSparkCount = 0;

    void Start()
    {
        Debug.Log("🌍 RealmLogic initialized.");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            timer = 0f;

            // Check for new sparks
            int sparkCount = SparkSystem.sparkLog.Count;

            if (sparkCount > lastSparkCount)
            {
                int newCount = sparkCount - lastSparkCount;
                lastSparkCount = sparkCount;

                Debug.Log($"⚡ RealmLogic: {newCount} new spark(s) detected.");

                // Print last spark
                string latest = SparkSystem.sparkLog[sparkCount - 1];
                Debug.Log($"🔥 Last Spark: {latest}");

                // 🔮 Future: react to spark type or keywords here
            }
        }
    }
}
