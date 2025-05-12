using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void LoadAceOfShadows()
    {
        SceneManager.LoadScene("AceOfShadows");
    }

    public void LoadMagicWords()
    {
        SceneManager.LoadScene("MagicWords");
    }

    public void LoadPhoenixFlame()
    {
        SceneManager.LoadScene("PhoenixFlame");
    }
}
