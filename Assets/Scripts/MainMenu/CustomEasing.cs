using UnityEngine;
using System.Collections;
using DentedPixel;

public class CustomEasing : MonoBehaviour
{
    public GameObject objectToAnimate;
    public float animationDuration = 0f;

    private Vector3 initialPosition;
    private Vector3 finalPosition;

    void Start()
    {
        // Pega as posições iniciais (pontos X)
        initialPosition = objectToAnimate.transform.localPosition;

        // Define as posições finais (pontos Y)
        finalPosition = new Vector3(xFinal, yFinal, zFinal);
    }

    // objectToAnimate
    float xFinal = 0f;
    float yFinal = 0f;
    float zFinal = 0f;

    public void StartAnimation()
    {
        objectToAnimate.transform.localPosition = initialPosition;

        LeanTween.moveLocal(objectToAnimate, finalPosition, animationDuration).setEase(LeanTweenType.easeInOutElastic);
    }
}
