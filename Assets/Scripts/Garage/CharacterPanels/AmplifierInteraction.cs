using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplifierInteraction : MonoBehaviour
{
    public GameObject amplifier; // Refer�ncia ao GameObject Amplifier (um cubo)
    public GameObject infoPanel; // Refer�ncia ao GameObject InfoPanel (painel da UI)
    public GameObject player; // Refer�ncia ao GameObject com a tag "Player"
    private PlayerController playerController; // Componente de controle do jogador
    public MouseCursorController cursorController;

    public float interactionDistance = 5f; // Dist�ncia de intera��o do jogador

    private bool isInteracting = false;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        cursorController = FindObjectOfType<MouseCursorController>();
    }

    private void Update()
    {
        // Verifica se o jogador est� mirando no Amplifier
        Ray ray = new Ray(player.transform.position, player.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == amplifier)
            {
                // O jogador est� mirando no Amplifier
                if (Input.GetKeyDown(KeyCode.F) && !isInteracting)
                {
                    // Quando o bot�o esquerdo do mouse � clicado e podemos interagir
                    infoPanel.SetActive(true); // Ativar o InfoPanel (painel da UI)

                    cursorController.ShowCursor();

                    // Desativa o controle de movimento do jogador
                    if (playerController != null)
                    {
                        playerController.CanMove = false;
                    }

                    // Voc� pode iniciar suas anima��es aqui, referenciando o script HeroesUpgradeAnimator
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
            // Desativa o InfoPanel quando a tecla ESC � pressionada
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