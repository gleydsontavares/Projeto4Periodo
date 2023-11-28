using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotel1 : MonoBehaviour
{
    public GameObject uiParaAtivar;

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
}
