using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplifierInteraction : MonoBehaviour
{
    public GameObject amplifier; // Referência ao GameObject Amplifier (um cubo)
    public GameObject infoPanel; // Referência ao GameObject InfoPanel (painel da UI)
    public GameObject player; // Referência ao GameObject com a tag "Player"
    private PlayerController playerController; // Componente de controle do jogador
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
        // Verifica se o jogador está mirando no Amplifier
        Ray ray = new Ray(player.transform.position, player.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == amplifier)
            {
                // O jogador está mirando no Amplifier
                if (Input.GetKeyDown(KeyCode.F) && !isInteracting)
                {
                    // Quando o botão esquerdo do mouse é clicado e podemos interagir
                    infoPanel.SetActive(true); // Ativar o InfoPanel (painel da UI)

                    cursorController.ShowCursor();

                    // Desativa o controle de movimento do jogador
                    if (playerController != null)
                    {
                        playerController.CanMove = false;
                    }

                    // Você pode iniciar suas animações aqui, referenciando o script HeroesUpgradeAnimator
                    HeroesUpgradeAnimator animator = amplifier.GetComponent<HeroesUpgradeAnimator>();
                    if (animator != null)
                    {
                        animator.StartAlexAnimation();
                        animator.StartOliverAnimation();
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

            // Ativa o controle de movimento do jogador
            if (playerController != null)
            {
                playerController.CanMove = true;
            }

            isInteracting = false;
        }
    }
}