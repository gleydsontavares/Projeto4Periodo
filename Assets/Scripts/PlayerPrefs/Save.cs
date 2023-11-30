using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private string chaveVolume = "Volume";

    // M�todo para salvar o volume
    public void SalvarVolume(float novoVolume)
    {
        PlayerPrefs.SetFloat(chaveVolume, novoVolume);
        PlayerPrefs.Save();
    }

    // M�todo para carregar o volume
    public float CarregarVolume()
    {
        return PlayerPrefs.GetFloat(chaveVolume, 1f); // Valor padr�o 0.5 se n�o houver nenhum salvo
    }
}
