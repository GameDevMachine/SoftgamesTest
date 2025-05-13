using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace MagicWords
{
    public class MagicWordsGameManager : MonoBehaviour
    {
        [SerializeField] private string DataURL = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";

        static MagicWordsGameManager instance;

        // cache pre-loaded avatar data
        private Dictionary<string, AvatarData> avatars = new Dictionary<string, AvatarData>();

        private DialogueData dialogueData;
        private int dialogueIndex = 0;
        private bool initDone = false;

        private void Awake()
        {
            instance = this;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void Start()
        {
            // retrieve data from provided endpoint
            StartCoroutine(RequestData(DataURL));
        }

        private void Update()
        {
            if (dialogueData == null) return;
            if (!initDone) return;

            if (Input.GetMouseButtonUp(0))
            {
                dialogueIndex++;
                DisplayDialogue();
            }
        }

        private void DisplayDialogue()
        {
            if (dialogueData == null) return;
            if (dialogueData.dialogue.Count <= dialogueIndex) return;

            DialogueLine line = dialogueData.dialogue[dialogueIndex];
            MagicWordsUI.DisplayDialogue(line);
        }

        // Static Interface

        public static AvatarData GetAvatar(string name)
        {
            if (instance.avatars.TryGetValue(name, out AvatarData avatar))
            {
                return avatar;
            }
            return null;
        }

        // Coroutines

        IEnumerator RequestData(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(DataURL))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Web Error: " + webRequest.error);
                    yield break;
                }
               
                dialogueData = JsonUtility.FromJson<DialogueData>(webRequest.downloadHandler.text);
            }

            // pre-load avatar images
            foreach (AvatarData avatar in dialogueData.avatars)
            {
                if (!avatars.ContainsKey(avatar.name))
                {
                    using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(avatar.url))
                    {
                        // Request and wait for the desired page.
                        yield return webRequest.SendWebRequest();

                        if (webRequest.result != UnityWebRequest.Result.Success)
                        {
                            Debug.LogError("Web Error: " + webRequest.error);
                            continue;
                        }

                        Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                        Sprite avatarSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                        avatar.sprite = avatarSprite;
                        avatars.Add(avatar.name, avatar);
                    }
                }
            }

            // Display the first dialogue line
            initDone = true;
            DisplayDialogue();
        }
    }
}

