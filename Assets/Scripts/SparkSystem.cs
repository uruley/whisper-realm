using System.Collections.Generic;
using UnityEngine;

public class SparkSystem : MonoBehaviour
{
    public static List<string> sparkLog = new List<string>();

    public static void TriggerSpark(string description)
    {
        string logEntry = $"✨ Spark Triggered: {description}";
        sparkLog.Add(logEntry);
        Debug.Log(logEntry);

        // 🔮 Future: Notify RealmLogic, trigger events, or update the world
    }

    public static void PrintRecentSparks()
    {
        Debug.Log("🗒 Recent Sparks:");
        foreach (string spark in sparkLog)
        {
            Debug.Log($" - {spark}");
        }
    }
}
