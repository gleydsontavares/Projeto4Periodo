using UnityEngine;
using UnityEngine.UI;

public class ExitConfirmation : MonoBehaviour
{
    public GameObject MiniGamePanel;
    

    public void MostrarPainel()
    {
        MiniGamePanel.SetActive(true);
    }

    public void CarregarMinigame()
    {
        
        Debug.Log("");
    }

    public void CancelarSaida()
    {
        MiniGamePanel.SetActive(false);
    }
}
