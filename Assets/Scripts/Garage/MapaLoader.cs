using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaLoader : MonoBehaviour
{
    public GameObject mapa; // O GameObject que voc� quer que o jogador esteja olhando
    public float distanciaMaxima = 5.0f; // A dist�ncia m�xima para o Raycast
    public string cenaTabuleiro = "Tabuleiro"; // Nome da cena que voc� quer carregar
    private bool olhandoParaMapa = false;

    void Update()
    {
        // Verifique se o jogador est� pressionando a tecla "F"
        if (Input.GetKeyDown(KeyCode.F) && olhandoParaMapa)
        {
            // Carregue a cena "Tabuleiro"
            SceneManager.LoadScene(cenaTabuleiro);
        }
    }

    void FixedUpdate()
    {
        // Crie um raio a partir da c�mera na dire��o do mapa
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        // Crie uma vari�vel para armazenar as informa��es da colis�o
        RaycastHit hit;

        // Verifique se o raio atinge o mapa
        if (Physics.Raycast(ray, out hit, distanciaMaxima))
        {
            if (hit.collider.gameObject == mapa)
            {
                // O jogador est� olhando para o mapa
                olhandoParaMapa = true;
            }
            else
            {
                olhandoParaMapa = false;
            }
        }
        else
        {
            olhandoParaMapa = false;
        }
    }
}
