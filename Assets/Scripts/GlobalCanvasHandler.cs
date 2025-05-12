using UnityEngine;

public class GlobalCanvasHandler : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
