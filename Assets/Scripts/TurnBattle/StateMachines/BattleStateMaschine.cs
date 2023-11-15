using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleStateMaschine : MonoBehaviour
{

    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,

    }



    public PerformAction battleStates;

    public List<HandleTurn> PerformList = new List<HandleTurn> ();

    public List<GameObject> HerosInBattle = new List<GameObject> ();
    public List<GameObject> EnemysInBattle = new List<GameObject> ();

    public enum HeroGUI
    {
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }

    public HeroGUI HeroInput;

    public List<GameObject> HerosToManage = new List<GameObject> ();
    private HandleTurn HeroChoise;

    public GameObject enemyButton;
    public Transform Spacer;

    public GameObject AttackPanel;
    public GameObject EnemySelectPanel;


    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemysInBattle.AddRange (GameObject.FindGameObjectsWithTag ("Enemy"));
        HerosInBattle.AddRange (GameObject.FindGameObjectsWithTag ("Hero"));
        HeroInput = HeroGUI.ACTIVATE;

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);

        EnemyButtons();
    }

    // Update is called once per frame
    void Update()
    {
        switch(battleStates)
        {
            case(PerformAction.WAIT):
                if(PerformList.Count > 0)
                {
                    battleStates = PerformAction.TAKEACTION;
                }

            break;

            case(PerformAction.TAKEACTION):
                GameObject performer = GameObject.Find(PerformList[0].Attacker);
                if (PerformList[0].Type == "Enemy")
                {
                    EnemyStateMaschine ESM = performer.GetComponent<EnemyStateMaschine> ();
                        for(int i = 0; i<HerosInBattle.Count; i++)
                        {
                            if (PerformList[0].AttackersTarget == HerosInBattle[i])
                            {
                            ESM.HeroToAttack = PerformList[0].AttackersTarget;
                            ESM.currentState = EnemyStateMaschine.TurnState.ACTION;
                            break;
                            }
                            else
                            {
                                PerformList[0].AttackersTarget = HerosInBattle[Random.Range(0,HerosInBattle.Count)];
                                ESM.HeroToAttack = PerformList[0].AttackersTarget;
                                ESM.currentState = EnemyStateMaschine.TurnState.ACTION;
                            }
                        }
                    
                }

                if (PerformList[0].Type == "Hero")
                {
                    HeroStateMaschine HSM = performer.GetComponent<HeroStateMaschine> ();
                    HSM.EnemyToAttack = PerformList[0].AttackersTarget;
                    HSM.currentState = HeroStateMaschine.TurnState.ACTION;
                }
                battleStates = PerformAction.PERFORMACTION;

                break;

            case(PerformAction.PERFORMACTION):
                //idle
            break;
        }

        switch (HeroInput)
        {
            case (HeroGUI.ACTIVATE):
                if(HerosToManage.Count > 0)
                {
                    HerosToManage[0].transform.FindChild("Selector").gameObject.SetActive (true);
                    HeroChoise = new HandleTurn();
                    AttackPanel.SetActive(true);
                    HeroInput = HeroGUI.WAITING;
                }

            break;
            
            case (HeroGUI.WAITING):
                //idle
            break;

            case (HeroGUI.DONE):
                HeroInputDone();
            break;

        }
    }

    public void CollectActions(HandleTurn input)
    {
        PerformList.Add (input);
    }

    void EnemyButtons()
    {
        foreach(GameObject enemy in EnemysInBattle)
        {
            GameObject newButton = Instantiate(enemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton> ();

            EnemyStateMaschine cur_enemy = enemy.GetComponent<EnemyStateMaschine> ();

            Text buttonText = newButton.transform.FindChild("Text (Legacy)").gameObject.GetComponent<Text>();
            buttonText.text = cur_enemy.enemy.theName;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent (Spacer, false);


        }
    }

    public void Input1() //attack button
    {
        HeroChoise.Attacker = HerosToManage[0].name;
        HeroChoise.AttackersGameObject = HerosToManage[0];
        HeroChoise.Type = "Hero";

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }

    public void Input2(GameObject choosenEnemy) //enemy selection
    {
        HeroChoise.AttackersTarget = choosenEnemy;
        HeroInput = HeroGUI.DONE;
    }

    void HeroInputDone()
    {
        PerformList.Add(HeroChoise);
        EnemySelectPanel.SetActive (false);
        HerosToManage[0].transform.FindChild("Selector").gameObject.SetActive(false);
        HerosToManage.RemoveAt (0);
        HeroInput = HeroGUI.ACTIVATE;
    }
}
