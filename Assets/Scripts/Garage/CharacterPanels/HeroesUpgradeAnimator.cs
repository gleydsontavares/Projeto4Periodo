using UnityEngine;
using System.Collections;
using DentedPixel;

public class HeroesUpgradeAnimator : MonoBehaviour
{
    public GameObject IMG_alex;
    public GameObject IMG_oliver;
    public GameObject Amplifier; // GameObject que o jogador interage
    public GameObject InfoPanel;

    private Vector3 startPosAlex;
    private Vector3 startPosOliver;

    // Alex
    float xFinalAlex = -670f;
    float yFinalAlex = 0f;
    float zFinalAlex = 0f;

    // Oliver
    float xFinalOliver = 670f;
    float yFinalOliver = 0f;
    float zFinalOliver = 0f;

    void Start()
    {
        // Salva as posi��es iniciais
        startPosAlex = IMG_alex.transform.localPosition;
        startPosOliver = IMG_oliver.transform.localPosition;
    }

    void StartAnimation(GameObject obj, Vector3 startPos, Vector3 finalPos, float duration)
    {
        // Reinicia a posi��o do objeto
        obj.transform.localPosition = startPos;

        // Inicie a anima��o
        LeanTween.moveLocal(obj, finalPos, duration).setEase(LeanTweenType.linear);
    }

    // Exemplo de como chamar a anima��o para Alex
    public void StartAlexAnimation()
    {
        StartAnimation(IMG_alex, startPosAlex, new Vector3(xFinalAlex, yFinalAlex, zFinalAlex), 1.0f);
    }

    // Exemplo de como chamar a anima��o para Oliver
    public void StartOliverAnimation()
    {
        StartAnimation(IMG_oliver, startPosOliver, new Vector3(xFinalOliver, yFinalOliver, zFinalOliver), 1.0f);
    }

    // Fun��o chamada quando o jogador clica com o bot�o direito no Amplifier
    private void PanelVerification()
    {
        if (InfoPanel.activeSelf)
        {
            // Inicie a anima��o apenas se o InfoPanel estiver aberto
            StartAlexAnimation();
            StartOliverAnimation();
        }
    }
}
