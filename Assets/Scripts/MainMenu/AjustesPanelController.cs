using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AjustesPanelController : MonoBehaviour
{
    public GameObject audioPanel;
    public GameObject controlesPanel;

    void Start()
    {
        // Encontrar o Save e GerenciadorSom na cena
        audioPanel.SetActive(false);
    }

    public void OpenAudioPanel()
    {
        audioPanel.SetActive(true);
        controlesPanel.SetActive(false);
    }

    public void OpenControlesPanel()
    {
        audioPanel.SetActive(false);
        controlesPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        audioPanel.SetActive(false);
        controlesPanel.SetActive(false);
    }

    public void ApplySettings()
    {

    }
}
