using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public TextMeshProUGUI pressAnyKeyText;
    public RawImage iconImage;
    public float fadeInDuration = 2.0f;
    public float fadeOutDuration = 2.0f;
    public string sceneToLoad = "MainMenu";

    private float startTime;
    private bool fadingIn = true;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;

        if (fadingIn)
        {
            if (elapsedTime < fadeInDuration)
            {
                float alpha = Mathf.Clamp01(elapsedTime / fadeInDuration);
                SetAlpha(alpha);
            }
            else
            {
                fadingIn = false;
                startTime = Time.time;
            }
        }
        else
        {
            if (elapsedTime < fadeOutDuration)
            {
                float alpha = Mathf.Clamp01(1 - (elapsedTime / fadeOutDuration));
                SetAlpha(alpha);
            }
            else
            {
                fadingIn = true;
                startTime = Time.time;
            }
        }

        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void SetAlpha(float alpha)
    {
        Color textAlpha = pressAnyKeyText.color;
        Color imageAlpha = iconImage.color;
        textAlpha.a = alpha;
        imageAlpha.a = alpha;
        pressAnyKeyText.color = textAlpha;
        iconImage.color = imageAlpha;
    }
}
