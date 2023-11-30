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

    private Save saveScript;
    private GerenciadorSom gerenciadorSom;

    void Start()
    {
        // Encontrar o Save e GerenciadorSom na cena
        saveScript = FindObjectOfType<Save>();
        gerenciadorSom = FindObjectOfType<GerenciadorSom>();

        // Configurar os sliders com os valores salvos
        if (saveScript != null)
        {
            musicVolumeSlider.value = saveScript.CarregarVolume();
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        }

        // Adicionar um listener para detectar mudanças no slider
        musicVolumeSlider.onValueChanged.AddListener(AtualizarVolumeSom);
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

        // Aplica as configurações de áudio no GerenciadorSom
        if (gerenciadorSom != null)
        {
            gerenciadorSom.AtualizarVolume(musicVolume);
        }

        // Salva as configurações em PlayerPrefs ou em um arquivo de configurações
        if (saveScript != null)
        {
            saveScript.SalvarVolume(musicVolume);
            PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        }
    }
    void AtualizarVolumeSom(float novoVolume)
    {
        Debug.Log("Novo Volume: " + novoVolume);

        if (gerenciadorSom != null && saveScript != null)
        {
            gerenciadorSom.AtualizarVolume(novoVolume);
            saveScript.SalvarVolume(novoVolume);
        }
    }
}
