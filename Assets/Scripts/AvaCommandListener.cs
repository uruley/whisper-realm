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

            if (!www.isNetworkError && !www.isHttpError)
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
        switch (command.ToLower())
        {
            case "show_ava":
                AvaObject.SetActive(true);
                Respond("Ava is here.");
                break;

            case "hide_ava":
                AvaObject.SetActive(false);
                Respond("Ava is hiding.");
                break;

            default:
                Respond("I received an unknown command: " + command);
                break;
        }
    }

    void Respond(string message)
    {
        // 🔵 Console confirmation
        Debug.Log("🧠 Ava says: " + message);

        // 🔲 Future: UI pop-up or speech synthesis can go here
        // e.g., DisplayOnUI(message);
        // e.g., PlayVoiceLine(message);
    }
}
