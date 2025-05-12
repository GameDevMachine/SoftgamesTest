using System.Collections;
using System.Collections.Generic;
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

        // Emoji support - taken from the default TMPRo font asset, should really have a nicer font with more emoji
        private Dictionary<string, string> emojiDictionary = new Dictionary<string, string>
        {
            { "{satisfied}", "\U0001F60A" },
            { "{intrigued}", "\U0001F609" },
            { "{neutral}", "\U0001F600" },
            { "{affirmative}", "\U0001F60E" },
            { "{laughing}", "\U0001F601" },
            { "{win}", "\U0001F60D" },
        };

        public void DisplayDialogue(DialogueLine dialogueLine)
        {
            if (dialogueLine == null) return;

            gameObject.SetActive(true);

            // parse emoji
            string speech = dialogueLine.text;
            foreach (KeyValuePair<string, string> emoji in emojiDictionary)
            {
                speech = speech.Replace(emoji.Key, emoji.Value);
            }
            speechText.text = speech;

            // reset avatar image
            avatarImage.sprite = null;

            // get new avatar image from URL
            AvatarData avatar = MagicWordsGameManager.GetAvatar(dialogueLine.name);
            if (avatar == null) return;
            avatarImage.sprite = avatar.sprite;
        }
    }
}

