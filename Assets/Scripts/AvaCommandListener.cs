using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AvaCommandListener : MonoBehaviour
{
    public GameObject AvaObject;

    private string lastCommand = "";
    private string endpoint = "https://voice-command-handler-242734186757.us-central1.run.app/latest-command";

    void Start()
    {
        StartCoroutine(PollForCommands());
    }

    IEnumerator PollForCommands()
    {
        while (true)
        {
            UnityWebRequest www = UnityWebRequest.Get(endpoint);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.ConnectionError && www.result != UnityWebRequest.Result.ProtocolError)
            {
                string command = www.downloadHandler.text.Trim();

                if (!string.IsNullOrEmpty(command) && command != lastCommand)
                {
                    Debug.Log("🔊 New command received: " + command);
                    lastCommand = command;
                    HandleCommand(command);
                }
            }
            else
            {
                Debug.LogWarning("Ava failed to poll commands: " + www.error);
            }

            yield return new WaitForSeconds(3);
        }
    }

    void HandleCommand(string command)
    {
        command = command.ToLower();

        if (command == "show_ava")
        {
            AvaObject.SetActive(true);
            Respond("Ava is here.");
        }
        else if (command == "hide_ava")
        {
            AvaObject.SetActive(false);
            Respond("Ava is hiding.");
        }
        else if (command.StartsWith("spark:"))
        {
            string sparkText = command.Substring(6).Trim();
            SparkSystem.TriggerSpark(sparkText);
            Respond($"A spark has been triggered: {sparkText}");
        }
        else
        {
            Respond("I received an unknown command: " + command);
        }
    }

    void Respond(string message)
    {
        Debug.Log("🧠 Ava says: " + message);
    }
}
