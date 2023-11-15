using UnityEngine;
using UnityEngine.UI;

public class ExitConfirmation : MonoBehaviour
{
    public GameObject ExitPanel; // Refer�ncia ao painel de confirma��o
    public Button BTN_sim; // Refer�ncia ao bot�o de confirmar
    public Button BTN_nao; // Refer�ncia ao bot�o de cancelar

    private void Start()
    {
        // Desativa o painel de confirma��o no in�cio do jogo
        ExitPanel.SetActive(false);

        // Adiciona os eventos de clique aos bot�es
        BTN_sim.onClick.AddListener(ConfirmarSaida);
        BTN_nao.onClick.AddListener(CancelarSaida);
    }

    public void MostrarPainel()
    {
        // Ativa o painel de confirma��o
        ExitPanel.SetActive(true);
    }

    public void ConfirmarSaida()
    {
        // Fecha a aplica��o
        Application.Quit();
        // Confirma��o visual no console
        Debug.Log("Aplica��o encerrada corretamente.");
    }

    public void CancelarSaida()
    {
        // Desativa o painel de confirma��o
        ExitPanel.SetActive(false);
    }
}
