using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSom : MonoBehaviour
{
    private static GerenciadorSom instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            // Inicie a m�sica aqui ou configure o AudioSource conforme necess�rio
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // M�todo para ajustar o volume
    public void AtualizarVolume(float novoVolume)
    {
        if (audioSource != null)
        {
            audioSource.volume = novoVolume;
        }
    }

    // M�todo para reproduzir uma m�sica espec�fica
    public void PlayMusic(AudioClip musicClip)
    {
        if (audioSource != null && musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
        }
    }

    // M�todo para parar a m�sica
    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

}
