using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsPanelController : MonoBehaviour
{
    public GameObject creditsPanel; // Arraste o painel de cr�ditos aqui
    
    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
}
