using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject computer;
    public GameObject infoPanel;
    public GameObject player;
    private PlayerController playerController;
    public MouseCursorController cursorController;
    public GameObject BuyButtons;

    public float interactionDistance = 5f; // Distância de interação do jogador

    private bool isInteracting = false;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        cursorController = FindObjectOfType<MouseCursorController>();
    }

    private void Update()
    {
        // Verifica se o jogador está mirando no Computador
        Ray ray = new Ray(player.transform.position, player.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == computer)
            {
                if (Input.GetKeyDown(KeyCode.F) && !isInteracting)
                {
                    
                    infoPanel.SetActive(true);

                    cursorController.ShowCursor();

                    if (playerController != null)
                    {
                        playerController.CanMove = false;
                    }

                    InstrumentAnimator animator = computer.GetComponent<InstrumentAnimator>();
                    if (animator != null)
                    {
                        animator.StartDrumsAnimation();
                        animator.StartKeyboardAnimation();
                    }

                    isInteracting = true;
                }
            }
        }

        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Desativa o InfoPanel quando a tecla ESC é pressionada
            infoPanel.SetActive(false);

            cursorController.HideCursor();

            BuyButtons.SetActive(false);

            // Ativa o controle de movimento do jogador
            if (playerController != null)
            {
                playerController.CanMove = true;
            }

            isInteracting = false;
        }
    }
}