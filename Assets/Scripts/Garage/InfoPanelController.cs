using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour
{
    public GameObject infoPanel; // Referência ao painel de informações

    private void Start()
    {
        // Desativa o painel de informações no início
        infoPanel.SetActive(false);
    }

    // Função chamada quando o botão é clicado para fechar o painel
    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }
}

