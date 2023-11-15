using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsPanelController : MonoBehaviour
{
    public GameObject creditsPanel; // Arraste o painel de créditos aqui
    public Button BTN_creditos; // Arraste o botão de créditos aqui
    public Button BTN_cross; // Arraste o botão para fechar os créditos aqui

    private void Start()
    {
        // Desativa o painel de créditos no início do jogo
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
