using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void OnExitClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

        static public void DisplayDialogue(DialogueLine dialogueLine, AvatarData avatar)
        {
            instance.ResetUI();
            if (dialogueLine == null) return;

            // Setup speaker
            if (avatar == null || avatar.position == "left")
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

