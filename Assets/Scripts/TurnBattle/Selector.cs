using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public float amplitude = .1f; // A amplitude da animação de subir e descer
    public float velocidadeSubirDescer = 10.0f; // A velocidade da animação de subir e descer
    public float velocidadeGirar = 20.0f; // A velocidade da animação de rotação

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Animar subir e descer
        float oscilacao = Mathf.Sin(Time.time * velocidadeSubirDescer);
        transform.position = posicaoInicial + new Vector3(0, oscilacao * amplitude, 0);

        // Animar rotação
        transform.rotation = Quaternion.Euler(45, Time.time * velocidadeGirar, 45);
    }
}
