using UnityEngine;

namespace MagicWords
{
    public class MagicWordsUI : MonoBehaviour
    {
        [SerializeField] private Speaker leftSpeaker;
        [SerializeField] private Speaker rightSpeaker;

        static MagicWordsUI instance;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            ResetUI();
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void ResetUI()
        {
            leftSpeaker.gameObject.SetActive(false);
            rightSpeaker.gameObject.SetActive(false);
        }

        static public void DisplayDialogue(DialogueLine dialogueLine, AvatarData avatar)
        {
            // Display the dialogue line in the UI
            Debug.Log($"Name: {dialogueLine.name}, Text: {dialogueLine.text}");

            instance.ResetUI();
            if (avatar == null) return;
            if (dialogueLine == null) return;

            // Setup speaker
            if (avatar.position == "left")
            {
                instance.leftSpeaker.DisplayDialogue(dialogueLine, avatar);
            }
            else
            {
                instance.rightSpeaker.DisplayDialogue(dialogueLine, avatar);
            }
        }
    }
}

