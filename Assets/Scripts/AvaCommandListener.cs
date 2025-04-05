using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AvaCommandListener : MonoBehaviour
{
    public GameObject AvaObject;
    private string lastCommand = "";

    void Start()
    {
        StartCoroutine(PollForCommands());
    }

    IEnumerator PollForCommands()
    {
        while (true)
        {
            UnityWebRequest www = UnityWebRequest.Get("https://voice-command-handler-242734186757.us-central1.run.app/latest-command");
            yield return www.SendWebRequest();

            if (!www.isNetworkError && !www.isHttpError)
            {
                string command = www.downloadHandler.text.Trim();

                if (command != lastCommand)
                {
                    lastCommand = command;
                    HandleCommand(command);
                }
            }

            yield return new WaitForSeconds(3);
        }
    }

    void HandleCommand(string command)
    {
        Debug.Log("Ava received command: " + command);

        if (command == "show_ava")
        {
            AvaObject.SetActive(true);
        }
        else if (command == "hide_ava")
        {
            AvaObject.SetActive(false);
        }
    }
}

