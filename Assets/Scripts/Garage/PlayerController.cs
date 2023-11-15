using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador.
    public Transform playerCamera; // Referência à câmera do jogador.
    public float mouseSensitivity = 2f; // Sensibilidade do mouse.

    public bool CanMove = true; // Variável para controlar o movimento do jogador.

    private float verticalRotation = 0f; // Rotação vertical da câmera.

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela.
        Cursor.visible = false; // Torna o cursor invisível.
    }

    private void Update()
    {
        if (CanMove)
        {
            // Captura os inputs de movimento do jogador.
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calcula o movimento do jogador.
            Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
            moveDirection.Normalize();

            // Aplica o movimento à posição do jogador.
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            // Captura a rotação do mouse.
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Rotaciona o jogador horizontalmente com base na rotação do mouse.
            transform.Rotate(Vector3.up * mouseX);

            // Rotaciona a câmera verticalmente com base na rotação do mouse e limita a rotação vertical.
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
            playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
    }
}
