using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhoenixFlame
{
    public class PhoenixFlameUI : MonoBehaviour
    {
        [SerializeField] private FireVFX fireVFX;

        static PhoenixFlameUI instance;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public void OnExitClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void OnFireGreenClicked()
        {
            fireVFX.SetGreen();
        }

        public void OnFireOrangeClicked()
        {
            fireVFX.SetOrange();
        }

        public void OnFireBlueClicked()
        {
            fireVFX.SetBlue();
        }
    }
}
