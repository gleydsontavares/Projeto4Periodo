using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipsManager : MonoBehaviour
{
    public GameObject IMG_tips_panel;
    public GameObject Dicas1;
    public GameObject Dicas2;
    public GameObject Dicas3;

    private void Start()
    {
        Dicas2.SetActive(false);
        Dicas3.SetActive(false);
    }

    public void OpenDicas2Panel()
    {
        Dicas2.SetActive(true);
        Dicas1.SetActive(false);
        Dicas3.SetActive(false);
    }

    public void OpenDicas3Panel()
    {
        Dicas3.SetActive(true);
        Dicas1.SetActive(false);
        Dicas2.SetActive(false);
    }

    public void ClosePanel()
    {
        Dicas1.SetActive(false);
        Dicas2.SetActive(false);
        Dicas3.SetActive(false);
        IMG_tips_panel.SetActive(false);
    }
}
