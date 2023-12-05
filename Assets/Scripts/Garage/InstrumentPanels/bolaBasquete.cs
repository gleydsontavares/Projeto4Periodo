using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaBasquete : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(moveHorizontal, 0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movimento * velocidade);
    }
}