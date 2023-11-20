using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    public GameObject IMG_turne;
    public GameObject TXT_objetivo_hotel;
    public GameObject TXT_objetivo_show;
    public GameObject IMG_moedas;
    public GameObject IMG_dia;
    public GameObject IMG_tips_panel;

    void Start()
    {
        // Pega as posições iniciais (pontos X)
        Vector3 startPosTurne = IMG_turne.transform.position;
        Vector3 startPosHotel = TXT_objetivo_hotel.transform.position;
        Vector3 startPosShow = TXT_objetivo_show.transform.position;
        Vector3 startPosMoedas = IMG_moedas.transform.position;
        Vector3 startPosDia = IMG_dia.transform.position;
        Vector3 startPosTips = IMG_tips_panel.transform.position;

        // Define as posições finais (pontos Y)
        Vector3 finalPosTurne = new Vector3(xFinalTurne, yFinalTurne, zFinalTurne);
        Vector3 finalPosHotel = new Vector3(xFinalHotel, yFinalHotel, zFinalHotel);
        Vector3 finalPosShow = new Vector3(xFinalShow, yFinalShow, zFinalShow);
        Vector3 finalPosMoedas = new Vector3(xFinalMoedas, yFinalMoedas, zFinalMoedas);
        Vector3 finalPosDia = new Vector3(xFinalDia, yFinalDia, zFinalDia);
        Vector3 finalPosTips = new Vector3(xFinalTips, yFinalTips, zFinalTips);

        // Move os botões para suas posições finais
        LeanTween.moveLocal(IMG_turne, finalPosTurne, 1.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(TXT_objetivo_hotel, finalPosHotel, 1.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(TXT_objetivo_show, finalPosShow, 1.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(IMG_moedas, finalPosMoedas, 3.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(IMG_dia, finalPosDia, 3.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(IMG_tips_panel, finalPosTips, 5.0f).setEase(LeanTweenType.easeOutBack);
    }

    // Turnê
    float xFinalTurne = -661f;
    float yFinalTurne = 388f;
    float zFinalTurne = 0f;

    // Hotel
    float xFinalHotel = -591f;
    float yFinalHotel = 184f;
    float zFinalHotel = 0f;

    // Show
    float xFinalShow = -591;
    float yFinalShow = 242f;
    float zFinalShow = 0f;

    // Moedas
    float xFinalMoedas = 730f;
    float yFinalMoedas = 388f;
    float zFinalMoedas = 0f;

    // Dia
    float xFinalDia = 846.5f;
    float yFinalDia = 303f;
    float zFinalDia = 0f;

    // Dicas
    float xFinalTips = 0.5f;
    float yFinalTips = -321f;
    float zFinalTips = 0f;
}
