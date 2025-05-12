using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace MagicWords
{
    public class Speaker : MonoBehaviour
    {
        [SerializeField] private Image avatarImage;
        [SerializeField] private TMP_Text speechText;

        public void DisplayDialogue(DialogueLine dialogueLine, AvatarData avatar)
        {
            if (avatar == null) return;
            if (dialogueLine == null) return;

            gameObject.SetActive(true);

            // set speech text
            speechText.text = dialogueLine.text;

            // reset avatar image
            avatarImage.sprite = null;

            // get new avatar image from URL
            StartCoroutine(DownloadAvatar(avatar.url));
        }

        IEnumerator DownloadAvatar(string avatarUrl)
        {
            using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(avatarUrl))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(": Error: " + webRequest.error);
                    yield break;
                }

                Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                Sprite avatarSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                avatarImage.sprite = avatarSprite;
            }
        }
    }
}

