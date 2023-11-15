using UnityEngine;
using System.Collections;
using DentedPixel;

public class ButtonAnimation : MonoBehaviour
{
    public GameObject BTN_jogar;
    public GameObject BTN_ajustes;
    public GameObject BTN_creditos;
    public GameObject BTN_sair;

    void Start()
    {
        // Pega as posições iniciais (pontos X)
        Vector3 startPosJogar = BTN_jogar.transform.position;
        Vector3 startPosAjustes = BTN_ajustes.transform.position;
        Vector3 startPosCreditos = BTN_creditos.transform.position;
        Vector3 startPosSair = BTN_sair.transform.position;

        // Define as posições finais (pontos Y)
        Vector3 finalPosJogar = new Vector3(xFinalJogar, yFinalJogar, zFinalJogar);
        Vector3 finalPosAjustes = new Vector3(xFinalAjustes, yFinalAjustes, zFinalAjustes);
        Vector3 finalPosCreditos = new Vector3(xFinalCreditos, yFinalCreditos, zFinalCreditos);
        Vector3 finalPosSair = new Vector3(xFinalSair, yFinalSair, zFinalSair);

        // Move os botões para suas posições finais
        LeanTween.moveLocal(BTN_jogar, finalPosJogar, 1.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(BTN_ajustes, finalPosAjustes, 3.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(BTN_creditos, finalPosCreditos, 5.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(BTN_sair, finalPosSair, 6.0f).setEase(LeanTweenType.easeOutBack);
    }

    // BTN_jogar
    float xFinalJogar = -666f;
    float yFinalJogar = -53f;
    float zFinalJogar = 0f;

    // BTN_ajustes
    float xFinalAjustes = -667f;
    float yFinalAjustes = -158f;
    float zFinalAjustes = 0f;

    // BTN_creditos
    float xFinalCreditos = -675f;
    float yFinalCreditos = -260f;
    float zFinalCreditos = 0f;

    // BTN_sair
    float xFinalSair = -700f;
    float yFinalSair = -364f;
    float zFinalSair = 0f;
}
