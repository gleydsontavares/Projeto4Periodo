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
            // Inicie a música aqui ou configure o AudioSource conforme necessário
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para ajustar o volume
    public void AtualizarVolume(float novoVolume)
    {
        if (audioSource != null)
        {
            audioSource.volume = novoVolume;
        }
    }

    // Método para reproduzir uma música específica
    public void PlayMusic(AudioClip musicClip)
    {
        if (audioSource != null && musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
        }
    }

    // Método para parar a música
    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

}
