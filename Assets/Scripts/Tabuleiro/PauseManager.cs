using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject cidade1Panel;
    public GameObject hotel1Panel;
    public GameObject hotel1Panel2;
    public GameObject hotel1Panel3;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                OpenPanel();
            
        }
    }

    public void OpenPanel()
    {
        // Ativa o painel de pausa.
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Pausa o tempo do jogo.
    }

    public void ClosePanel()
    {
        // Desativa o painel de pausa.
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Reseta o tempo do jogo para o valor normal.
    }

    public void OpenScene(string sceneName)
    {
        // Carrega a cena com o nome especificado.
        SceneManager.LoadScene(sceneName);
    }

    public void ClosePanelCidade1()
    {
        // Desativa o painel de pausa.
        cidade1Panel.SetActive(false);
        Time.timeScale = 1f; // Reseta o tempo do jogo para o valor normal.
    }
    public void ClosePanelHotel1()
    {
        // Desativa o painel de pausa.
        hotel1Panel.SetActive(false);
        Time.timeScale = 1f; // Reseta o tempo do jogo para o valor normal.
    }
    public void nextPanelHotel1()
    {
        // Desativa o painel de pausa.
        hotel1Panel.SetActive(false);
        hotel1Panel2.SetActive(true);
        
    }
    
    public void next2PanelHotel1()
    {
        // Desativa o painel de pausa.
        hotel1Panel2.SetActive(false);
        hotel1Panel3.SetActive(true);
    }

    public void CloseAllPanelHotel1()
    {
        // Desativa o painel de pausa.
        hotel1Panel.SetActive(false);
        hotel1Panel2.SetActive(false);
        hotel1Panel3.SetActive(false);
        Time.timeScale = 1f; // Reseta o tempo do jogo para o valor normal.
    }

    public void OpenMiniGame(string MiniGame)
    {
        // Carrega a cena com o nome especificado.
        SceneManager.LoadScene(MiniGame);
    }

}
