using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float gravity = 9.81f; // Ajuste conforme necess�rio

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela.
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        ApplyGravity();

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Use SimpleMove to handle gravity
            controller.SimpleMove(moveDir.normalized * speed);

            // Atualiza as anima��es
            UpdateAnimations(direction);
        }
        else
        {
            // Se n�o houver movimento, reproduzir anima��o de idle
            animator.SetFloat("Speed", 0f);
        }
    }

    void UpdateAnimations(Vector3 direction)
    {
        // Calcula a velocidade do movimento para a anima��o
        float animationSpeed = new Vector2(direction.x, direction.z).sqrMagnitude;

        // Atualiza o par�metro Speed no Animator
        animator.SetFloat("Speed", animationSpeed);
    }

    void ApplyGravity()
    {
        // Aplica a gravidade
        Vector3 verticalVelocity = Vector3.up * -gravity * Time.deltaTime;
        controller.Move(verticalVelocity);
    }
}
