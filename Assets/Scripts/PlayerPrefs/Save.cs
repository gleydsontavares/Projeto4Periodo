using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private string chaveVolume = "Volume";

    // Método para salvar o volume
    public void SalvarVolume(float novoVolume)
    {
        PlayerPrefs.SetFloat(chaveVolume, novoVolume);
        PlayerPrefs.Save();
    }

    // Método para carregar o volume
    public float CarregarVolume()
    {
        return PlayerPrefs.GetFloat(chaveVolume, 1f); // Valor padrão 0.5 se não houver nenhum salvo
    }
}
