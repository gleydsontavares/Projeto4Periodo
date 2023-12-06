using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapaLoader : MonoBehaviour
{
    public GameObject mapa;
    public float distanciaMaxima = 5.0f;
    public GameObject uiMapa;
    private bool olhandoParaMapa = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && olhandoParaMapa)
        {
            uiMapa.SetActive(true);
            PausarJogo(true);
        }
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distanciaMaxima))
        {
            if (hit.collider.gameObject == mapa)
            {
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
    void PausarJogo(bool pausar)
    {
        if (pausar)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}