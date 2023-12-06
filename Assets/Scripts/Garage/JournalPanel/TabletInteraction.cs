using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletInteraction : MonoBehaviour
{
    public GameObject tablet;
    public GameObject infoPanel;
    public GameObject player;
    public Scrollbar scrollbar;
    public RawImage rawImage;
    
    private bool jornalAberto = false;
    public float interactionDistance = 5f; 
    private bool isInteracting = false;
    

    private void Update()
    {
        Ray ray = new Ray(player.transform.position, player.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == tablet)
            {
                if (Input.GetKeyDown(KeyCode.F) && !isInteracting)
                {
                    jornalAberto = true;
                    infoPanel.SetActive(true);
                    Time.timeScale = 0.0f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    isInteracting = true;
                }
            }
        }
        
        if (isInteracting)
        {
            // Verifica se o scrollbar foi movido
            if (scrollbar != null && rawImage != null)
            {
                float scrollbarValue = scrollbar.value; // Obtém o valor atual do scrollbar
                float rawImageHeight = rawImage.rectTransform.rect.height;
                float infoPanelHeight = infoPanel.GetComponent<RectTransform>().rect.height;

                // Calcula a nova posição Y para o RawImage com base no valor do scrollbar
                float newY = (rawImageHeight - infoPanelHeight) * scrollbarValue;

                // Define a nova posição Y para o RawImage
                rawImage.rectTransform.anchoredPosition = new Vector2(rawImage.rectTransform.anchoredPosition.x, newY);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            infoPanel.SetActive(false);
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isInteracting = false;
        }
    }
    
}