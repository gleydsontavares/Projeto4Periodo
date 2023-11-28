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
        CHECKALIVE,
        WIN,
        LOSE

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

    public List<GameObject> HerosToManage = new List<GameObject>();
    private HandleTurn HeroChoise;

    public GameObject enemyButton;
    public Transform Spacer;

    public GameObject AttackPanel;
    public GameObject EnemySelectPanel;
    public GameObject MagicPanel;

    //attack of heros
    public Transform actionSpacer;
    public Transform magicSpacer;
    public GameObject actionButton;
    public GameObject magicButton;
    private List<GameObject> atkBtns = new List<GameObject>();

    //enemy buttons
    private List<GameObject> enemyBtns = new List<GameObject>();

    public GameObject winCanvas;
    public GameObject textDerrota;
    public GameObject textVitoria;
    public GameObject buttonJogarNovamente;
    public GameObject buttonContinuar;


    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemysInBattle.AddRange (GameObject.FindGameObjectsWithTag ("Enemy"));
        HerosInBattle.AddRange (GameObject.FindGameObjectsWithTag ("Hero"));
        HeroInput = HeroGUI.ACTIVATE;
        
        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);
        MagicPanel.SetActive(false);
        

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
            
            case(PerformAction.CHECKALIVE):
                if (HerosInBattle.Count < 1)
                {
                    battleStates = PerformAction.LOSE;
                    //lose game
                }
                else if (EnemysInBattle.Count < 1)
                {
                    battleStates = PerformAction.WIN;
                    //win the battle
                }
                else
                {

                    //call function
                    clearAttackPanel();
                    HeroInput = HeroGUI.ACTIVATE;
                }
                    
            break;

            case (PerformAction.LOSE):
                {
                    Debug.Log("You Lost the Battle");
                    winCanvas.SetActive(true);
                    buttonContinuar.SetActive(false);
                    textVitoria.SetActive(false);
                }
            break;
            case (PerformAction.WIN):
                {
                    Debug.Log("You Win the Battle");

                    winCanvas.SetActive(true);
                    textDerrota.SetActive(false);
                    textVitoria.SetActive(true);

                    for (int i = 0; i < HerosInBattle.Count;i++)
                    {
                        HerosInBattle[i].GetComponent<HeroStateMaschine>().currentState = HeroStateMaschine.TurnState.WAITING;
                    }
                }
            break;
        }

        switch (HeroInput)
        {
            case (HeroGUI.ACTIVATE):
                if(HerosToManage.Count > 0)
                {
                    HerosToManage[0].transform.FindChild("Selector").gameObject.SetActive (true);
                    //create new handleturn instance
                    HeroChoise = new HandleTurn();

                    AttackPanel.SetActive(true);
                    //populate action buttons
                    CreateAttackButtons();
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

    public void EnemyButtons()
    {
        //cleanup
        foreach(GameObject enemyBtn in enemyBtns)
        {
            Destroy(enemyBtn);
        }
        enemyBtns.Clear ();
        //create buttons
        foreach(GameObject enemy in EnemysInBattle)
        {
            GameObject newButton = Instantiate(enemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton> ();

            EnemyStateMaschine cur_enemy = enemy.GetComponent<EnemyStateMaschine> ();

            Text buttonText = newButton.transform.FindChild("Text (Legacy)").gameObject.GetComponent<Text>();
            buttonText.text = cur_enemy.enemy.theName;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent (Spacer, false);
            enemyBtns.Add(newButton);


        }
    }

    public void Input1() //attack button
    {
        HeroChoise.Attacker = HerosToManage[0].name;
        HeroChoise.AttackersGameObject = HerosToManage[0];
        HeroChoise.Type = "Hero";
        HeroChoise.choosenAttack = HerosToManage[0].GetComponent<HeroStateMaschine>().hero.attacks[0];

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

        //clean the attackpanel
        clearAttackPanel();


        HerosToManage[0].transform.FindChild("Selector").gameObject.SetActive(false);
        HerosToManage.RemoveAt (0);
        HeroInput = HeroGUI.ACTIVATE;
    }

    void clearAttackPanel()
    {
        EnemySelectPanel.SetActive(false);
        AttackPanel.SetActive(false);
        MagicPanel.SetActive(false);

        foreach (GameObject atkBtn in atkBtns)
        {
            Destroy(atkBtn);
        }
        atkBtns.Clear();
    }




    //create actionbuttons
    void CreateAttackButtons()
    {
        GameObject AttackButton = Instantiate(actionButton) as GameObject;
        Text AttackButtonText = AttackButton.transform.FindChild("Text").gameObject.GetComponent<Text>();
        AttackButtonText.text = "Attack";
        AttackButton.GetComponent<Button>().onClick.AddListener(() => Input1());
        AttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(AttackButton);

        GameObject MagicAttackButton = Instantiate(actionButton) as GameObject;
        Text MagicAttackButtonText = MagicAttackButton.transform.FindChild("Text").gameObject.GetComponent<Text>();
        MagicAttackButtonText.text = "Magic";
        MagicAttackButton.GetComponent<Button>().onClick.AddListener(() => Input3());
        MagicAttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(MagicAttackButton);

        if (HerosToManage[0].GetComponent<HeroStateMaschine>().hero.MagicAttacks.Count > 0)
        {
            foreach(BaseAttack magicAtk in HerosToManage[0].GetComponent<HeroStateMaschine>().hero.MagicAttacks)
            {
                GameObject MagicButton = Instantiate(magicButton) as GameObject;
                Text MagicButtonText = MagicButton.transform.FindChild("Text").gameObject.GetComponent<Text>();
                MagicButtonText.text = magicAtk.attackName;
                AttackButton ATB = magicButton.GetComponent<AttackButton>();
                ATB.magicAttackToPerform = magicAtk;
                MagicButton.transform.SetParent(magicSpacer, false);
                atkBtns.Add(MagicButton);
            }
        }
        else
        {
            MagicAttackButton.GetComponent<Button>().interactable = false;
        }
    }

    public void Input4(BaseAttack choosenMagic)//choosen magic attack
    {
        HeroChoise.Attacker = HerosToManage[0].name;
        HeroChoise.AttackersGameObject = HerosToManage[0];
        HeroChoise.Type = "Hero";

        HeroChoise.choosenAttack = choosenMagic;
        MagicPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }

    public void Input3()//switching to magic attacks
    {
        AttackPanel.SetActive(false);
        MagicPanel.SetActive(true);
    }
}
