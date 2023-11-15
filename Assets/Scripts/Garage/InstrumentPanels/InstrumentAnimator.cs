using UnityEngine;
using System.Collections;
using DentedPixel;
using UnityEngine.UI;

public class InstrumentAnimator : MonoBehaviour
{
    public GameObject IMG_drums;
    public GameObject IMG_keyboard;
    public GameObject interactableObject;
    public GameObject InfoPanel;
    public GameObject BuyButtons;

    private Vector3 startPosDrums;
    private Vector3 startPosKeyboard;

    // Bateria
    float xFinalDrums = -670f;
    float yFinalDrums = 0f;
    float zFinalDrums = 0f;

    // Teclado
    float xFinalKeyboard = 670f;
    float yFinalKeyboard = 0f;
    float zFinalKeyboard = 0f;

    void Start()
    {
        startPosDrums = IMG_drums.transform.localPosition;
        startPosKeyboard = IMG_keyboard.transform.localPosition;
    }

    void StartAnimation(GameObject obj, Vector3 startPos, Vector3 finalPos, float duration)
    {
        obj.transform.localPosition = startPos;

        LeanTween.moveLocal(obj, finalPos, duration).setEase(LeanTweenType.linear).setOnComplete(() =>
        {
            StartCoroutine(ActivateButtonsAfterAnimation());
        });
    }

    IEnumerator ActivateButtonsAfterAnimation()
    {
        yield return new WaitForSeconds(0.3f);

        BuyButtons.SetActive(true);
    }

    public void StartDrumsAnimation()
    {
        StartAnimation(IMG_drums, startPosDrums, new Vector3(xFinalDrums, yFinalDrums, zFinalDrums), 1.0f);
    }

    public void StartKeyboardAnimation()
    {
        StartAnimation(IMG_keyboard, startPosKeyboard, new Vector3(xFinalKeyboard, yFinalKeyboard, zFinalKeyboard), 1.0f);
    }

    private void PanelVerification()
    {
        if (InfoPanel.activeSelf)
        {
            StartDrumsAnimation();
            StartKeyboardAnimation();
        }

    }
}
