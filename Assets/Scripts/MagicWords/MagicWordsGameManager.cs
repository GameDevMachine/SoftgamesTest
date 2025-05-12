using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace MagicWords
{
    public class MagicWordsGameManager : MonoBehaviour
    {
        [SerializeField] private string DataURL = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";

        private DialogueData dialogueData;
        private int dialogueIndex = 0;

        void Start()
        {
            // retrieve data from provided endpoint
            StartCoroutine(GetRequest(DataURL));
        }

        private void SetupGame()
        {
            DisplayDialogue();
        }

        private void DisplayDialogue()
        {
            if (dialogueData == null) return;
            if (dialogueData.dialogue.Count <= dialogueIndex) return;

            DialogueLine line = dialogueData.dialogue[dialogueIndex];
            AvatarData avatarData = dialogueData.avatars.Find(avatar => avatar.name == line.name);

            MagicWordsUI.DisplayDialogue(line, avatarData);
        }

        IEnumerator GetRequest(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(DataURL))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(": Error: " + webRequest.error);
                    yield break;
                }
                else
                { 
                    dialogueData = JsonUtility.FromJson<DialogueData>(webRequest.downloadHandler.text);
                    SetupGame();
                }
            }
        }
    }
}

