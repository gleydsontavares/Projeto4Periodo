using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garagem : MonoBehaviour
{
    public GameObject uiParaAtivar;
    public float elevacaoAoPassarMouse = 0.2f; // Altura que o objeto será elevado ao passar o mouse
    private Vector3 posicaoInicial; // Posição inicial do objeto

    void Start()
    {
        // Salva a posição inicial do objeto
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi clicado
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast a partir da posição do mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verifica se o raycast atingiu o objeto desejado
            if (Physics.Raycast(ray, out hit))
            {
                // Se o objeto atingido for o objeto desejado
                if (hit.collider.gameObject == this.gameObject)
                {
                    // Ativa a UI
                    if (uiParaAtivar != null)
                    {
                        uiParaAtivar.SetActive(true);
                    }
                }
            }
        }
    }

    void OnMouseOver()
    {
        // Eleva o objeto ao passar o mouse sobre ele
        ElevaObjeto();
    }

    void OnMouseExit()
    {
        // Retorna o objeto à sua posição inicial ao retirar o mouse
        transform.position = posicaoInicial;
    }

    void ElevaObjeto()
    {
        // Eleva o objeto na vertical
        Vector3 novaPosicao = posicaoInicial + new Vector3(0, elevacaoAoPassarMouse, 0);
        transform.position = novaPosicao;
    }
}