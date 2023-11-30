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
    public GameObject garagemPanel;

    public AudioSource backgroundMusic;

    private bool isPaused;

    private void Start()
    {
        pausePanel.SetActive(false);
        isPaused = false;
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
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }

        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ClosePanel()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.UnPause();
        }

        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenScene(string sceneName)
    {
        // Carrega a cena com o nome especificado.
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
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
    public void ClosePanelGarage()
    {
        // Desativa o painel de pausa.
        garagemPanel.SetActive(false);
        Time.timeScale = 1f; // Reseta o tempo do jogo para o valor normal.
    }

    public void OpenMiniGame(string MiniGame)
    {
        // Carrega a cena com o nome especificado.
        SceneManager.LoadScene(MiniGame);
    }
}
