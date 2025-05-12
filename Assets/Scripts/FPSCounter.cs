using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float refreshRate = 0.5f;

    float timer;
    int frames;

    void Update()
    {
        if (timer < refreshRate)
        {
            frames++;
            timer += Time.unscaledDeltaTime;
        }
        else
        {
            int fps = (int)(frames / timer);
            text.text = $"{fps} FPS";

            timer -= refreshRate;
            frames = 0;
        }
    }
}
