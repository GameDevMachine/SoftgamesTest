using UnityEngine;
using UnityEngine.SceneManagement;

namespace AceOfShadows
{
    public class AceGameUI : MonoBehaviour
    {
        [SerializeField] private GameObject gameFinishedUI;

        private static AceGameUI instance; // singleton

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
            gameFinishedUI.SetActive(false);
        }

        public void OnExitClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }


        // Static interface

        public static void ShowGameFinishedUI()
        {
            if (instance == null) return;
            instance.gameFinishedUI.SetActive(true);
        }
    }
}

