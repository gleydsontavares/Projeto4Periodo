using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressToKey : MonoBehaviour
{
    public TextMeshProUGUI pressAnyKeyText;
    public RawImage iconImage;
    public float fadeInDuration = 2.0f;
    public float fadeOutDuration = 2.0f;
    public GameObject pressKeyDown;

    private float startTime;
    private bool fadingIn = true;

    private void Start()
    {
        startTime = Time.time;

        if (pressKeyDown != null)
        {
            pressKeyDown.SetActive(true);
        }
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
            if (pressKeyDown != null)
            {
                pressKeyDown.SetActive(false);
            }
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

