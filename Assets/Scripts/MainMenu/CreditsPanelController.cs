using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsPanelController : MonoBehaviour
{
    public GameObject creditsPanel; // Arraste o painel de cr�ditos aqui
    public Button BTN_creditos; // Arraste o bot�o de cr�ditos aqui
    public Button BTN_cross; // Arraste o bot�o para fechar os cr�ditos aqui

    private void Start()
    {
        // Desativa o painel de cr�ditos no in�cio do jogo
        creditsPanel.SetActive(false);

        // Configura os eventos de clique
        BTN_creditos.onClick.AddListener(ShowCredits);
        BTN_cross.onClick.AddListener(CloseCredits);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
}
