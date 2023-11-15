using UnityEngine;
using UnityEngine.UI;

public class ExitConfirmation : MonoBehaviour
{
    public GameObject ExitPanel; // Referência ao painel de confirmação
    public Button BTN_sim; // Referência ao botão de confirmar
    public Button BTN_nao; // Referência ao botão de cancelar

    private void Start()
    {
        // Desativa o painel de confirmação no início do jogo
        ExitPanel.SetActive(false);

        // Adiciona os eventos de clique aos botões
        BTN_sim.onClick.AddListener(ConfirmarSaida);
        BTN_nao.onClick.AddListener(CancelarSaida);
    }

    public void MostrarPainel()
    {
        // Ativa o painel de confirmação
        ExitPanel.SetActive(true);
    }

    public void ConfirmarSaida()
    {
        // Fecha a aplicação
        Application.Quit();
        // Confirmação visual no console
        Debug.Log("Aplicação encerrada corretamente.");
    }

    public void CancelarSaida()
    {
        // Desativa o painel de confirmação
        ExitPanel.SetActive(false);
    }
}
