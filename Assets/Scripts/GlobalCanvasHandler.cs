using UnityEngine;

public class GlobalCanvasHandler : MonoBehaviour
{
    private static GlobalCanvasHandler instance; // singleton

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
