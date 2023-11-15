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
        // Salva as posições iniciais
        startPosAlex = IMG_alex.transform.localPosition;
        startPosOliver = IMG_oliver.transform.localPosition;
    }

    void StartAnimation(GameObject obj, Vector3 startPos, Vector3 finalPos, float duration)
    {
        // Reinicia a posição do objeto
        obj.transform.localPosition = startPos;

        // Inicie a animação
        LeanTween.moveLocal(obj, finalPos, duration).setEase(LeanTweenType.linear);
    }

    // Exemplo de como chamar a animação para Alex
    public void StartAlexAnimation()
    {
        StartAnimation(IMG_alex, startPosAlex, new Vector3(xFinalAlex, yFinalAlex, zFinalAlex), 1.0f);
    }

    // Exemplo de como chamar a animação para Oliver
    public void StartOliverAnimation()
    {
        StartAnimation(IMG_oliver, startPosOliver, new Vector3(xFinalOliver, yFinalOliver, zFinalOliver), 1.0f);
    }

    // Função chamada quando o jogador clica com o botão direito no Amplifier
    private void PanelVerification()
    {
        if (InfoPanel.activeSelf)
        {
            // Inicie a animação apenas se o InfoPanel estiver aberto
            StartAlexAnimation();
            StartOliverAnimation();
        }
    }
}
