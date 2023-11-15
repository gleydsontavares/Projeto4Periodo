using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class TrackSwitcher : MonoBehaviour
{
    Cinemachine.CinemachineDollyCart cart;

    public Cinemachine.CinemachineSmoothPath startPath;
    public Cinemachine.CinemachineSmoothPath[] alternatePaths;


    private void Awake()
    {
        cart = GetComponent<Cinemachine.CinemachineDollyCart>();

        Reset();
    }

    private void Reset ()
    {
        StopAllCoroutines();

        cart.m_Path = startPath;

        StartCoroutine(ChangeTrack());
    }
  
    IEnumerator ChangeTrack()
    {
        yield return new WaitForSeconds(Random.Range(4, 6));

        var path = alternatePaths[Random.Range(0, alternatePaths.Length)];
        cart.m_Path = path;

        StartCoroutine(ChangeTrack());

    }
    void Update()
    {
        
    }
}
