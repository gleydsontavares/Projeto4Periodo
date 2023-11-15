using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Amplifier : MonoBehaviour
{
    public Material originalMaterial;
    public Material alternateMaterial;
    public GameObject infoPanel;

    private bool isPlayerInside;
    private bool infoPanelActive;

    private Renderer amplifierRenderer;

    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        amplifierRenderer = GetComponent<Renderer>();
        infoPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            amplifierRenderer.material = alternateMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            amplifierRenderer.material = originalMaterial; // Volta ao material original ou coloque o material padrão aqui.
            if (infoPanelActive)
            {
                CloseInfoPanel();
            }
        }
    }

    private void Update()
    {
        if (isPlayerInside)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!infoPanelActive)
                {
                    OpenInfoPanel();
                }
                else
                {
                    CloseInfoPanel();
                }
            }
        }
    }

    private void OpenInfoPanel()
    {
        infoPanel.SetActive(true);
        infoPanelActive = true;
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        virtualCamera.gameObject.SetActive(false);
    }

    private void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        infoPanelActive = false;
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked; // Pode ser CursorLockMode.Confined se preferir
        Cursor.visible = false;
        virtualCamera.gameObject.SetActive(true);
    }
}
