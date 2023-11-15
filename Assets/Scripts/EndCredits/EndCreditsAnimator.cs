using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using DentedPixel;

public class EndCreditsAnimator : MonoBehaviour
{
    public GameObject creditsObject;
    public float duration = 20.0f;

    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private bool animationComplete = false;

    void Start()
    {
        initialPosition = new Vector3(0f, -850f, 0f);
        finalPosition = new Vector3(0f, 1187f, 0f);

        LeanTween.moveLocal(creditsObject, finalPosition, duration)
            .setEase(LeanTweenType.linear);
    }

    private void Update()
    {
        if (!animationComplete && LeanTween.isTweening(creditsObject) == false)
        {
            animationComplete = true;
            Debug.Log("Créditos chegaram ao final.");

            Invoke("LoadMainMenu", 3.0f);
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
