using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithBoard : MonoBehaviour
{
    public float interactDistance = 2f; // Distância máxima para interação
    public KeyCode interactKey = KeyCode.F;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Tabuleiro"))
            {
                LoadNewScene();
            }
        }
    }

    void LoadNewScene()
    {
        // Carregar a nova cena. Substitua "NomeDaCena" pelo nome da sua nova cena.
        SceneManager.LoadScene("Tabuleiro");

        // Ativar o cursor do mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
