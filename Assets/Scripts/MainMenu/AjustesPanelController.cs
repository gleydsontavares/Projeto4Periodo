using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AjustesPanelController : MonoBehaviour
{
    public GameObject audioPanel;
    public GameObject controlesPanel;

    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    public AudioSource musicAudioSource;

    private void Start()
    {
        // Desativa o painel no início da cena
        audioPanel.SetActive(false);
        controlesPanel.SetActive(false);
    }

        public void OpenAudioPanel()
    {
        audioPanel.SetActive(true);
        controlesPanel.SetActive(false);
    }

    public void OpenControlesPanel()
    {
        audioPanel.SetActive(false);
        controlesPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        audioPanel.SetActive(false);
        controlesPanel.SetActive(false);
    }

    public void ApplySettings()
    {
        // Salva as configurações de áudio
        float musicVolume = musicVolumeSlider.value;
        float sfxVolume = sfxVolumeSlider.value;

        // Aplica as configurações de áudio
        musicAudioSource.volume = musicVolume;

        // Salva as configurações em PlayerPrefs ou em um arquivo de configurações
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }
}
