using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectButton : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public void SelectEnemy()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMaschine>().Input2(EnemyPrefab); // save input enemy prefab
    }

    public void HideSelector()
    {
        EnemyPrefab.transform.FindChild("Selector").gameObject.SetActive(false);
    }

    public void ShowSelector()
    {
        EnemyPrefab.transform.FindChild("Selector").gameObject.SetActive(true);
    }
}
