using UnityEngine;
using System.Collections;
using DentedPixel;

public class HeroesAnimation : MonoBehaviour
{
    public GameObject IMG_menu_heroes;

    void Start()
    {
        // Posi��o inicial (pontos X)
        Vector3 startPosHeroes = IMG_menu_heroes.transform.position;

        // Posi��o final (pontos Y)
        Vector3 finalPosHeroes = new Vector3(xFinal, yFinal, zFinal);

        // Move o objeto para suas posi��es finais
        LeanTween.moveLocal(IMG_menu_heroes, finalPosHeroes, 2.0f).setEase(LeanTweenType.easeOutBack);
    }

    // IMG_menu_heroes
    float xFinal = 484f;
    float yFinal = -92.5f;
    float zFinal = -5f;

}
