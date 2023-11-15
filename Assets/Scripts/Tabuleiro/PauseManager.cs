using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

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
}
