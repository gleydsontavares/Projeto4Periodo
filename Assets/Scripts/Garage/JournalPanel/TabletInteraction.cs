using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletInteraction : MonoBehaviour
{
    public GameObject tablet;
    public GameObject infoPanel;
    public GameObject player;
    private PlayerController playerController;
    public MouseCursorController cursorController;

    public float interactionDistance = 5f; // Distância de interação do jogador

    private bool isInteracting = false;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        cursorController = FindObjectOfType<MouseCursorController>();
    }

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

                    infoPanel.SetActive(true);

                    cursorController.ShowCursor();

                    if (playerController != null)
                    {
                        playerController.CanMove = false;
                    }

                    isInteracting = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            infoPanel.SetActive(false);

            cursorController.HideCursor();

            if (playerController != null)
            {
                playerController.CanMove = true;
            }

            isInteracting = false;
        }
    }
}