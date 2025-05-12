using UnityEngine;

namespace MagicWords
{
    public class MagicWordsUI : MonoBehaviour
    {
        static MagicWordsUI instance;

        private void Awake()
        {
            instance = this;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        static public void DisplayDialogue(DialogueLine dialogueLine, AvatarData avatar)
        {
            // Display the dialogue line in the UI
            Debug.Log($"Name: {dialogueLine.name}, Text: {dialogueLine.text}");
        }
    }
}

