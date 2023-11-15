using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateMaschine : MonoBehaviour
{
    private BattleStateMaschine BSM;
    
    public BaseEnemy enemy;

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD
    }


    public TurnState currentState;
    
    // para o ProgressBar
    private float cur_cooldown = 0f;
    private float max_cooldown = 10f;
    
    //this gameObject
    private Vector3 startposition;
    public GameObject Selector;

    //timeforaction stuff
    private bool actionStarted = false;
    public GameObject HeroToAttack;
    private float animSpeed = 5f;
    
    
    void Start()
    {
        currentState = TurnState.PROCESSING;
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMaschine>();
        startposition = transform.position;
    }


       void Update()
    {
        Debug.Log (currentState);
            
        switch(currentState)
        {
            
            case (TurnState.PROCESSING):
                UpgradeProgressBar ();
            
            break;

            case (TurnState.CHOOSEACTION):
                ChooseAction();
                currentState = TurnState.WAITING;
            break;

            case (TurnState.WAITING):
                //idle state
            break;
                          
            case (TurnState.ACTION):
                StartCoroutine(TimeForAction());
            break;

            case (TurnState.DEAD):

            break;

        }
    }

    void UpgradeProgressBar()
    {
        cur_cooldown = cur_cooldown + Time.deltaTime;

        
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.CHOOSEACTION;
        }
    }

    void ChooseAction()
    {
        HandleTurn myAttack = new HandleTurn ();
        myAttack.Attacker = enemy.theName;
        myAttack.Type = "Enemy";
        myAttack.AttackersGameObject = this.gameObject;
        myAttack.AttackersTarget = BSM.HerosInBattle[Random.Range(0, BSM.HerosInBattle.Count)];
        
        int num = Random.Range(0, enemy.attacks.Count);
        myAttack.choosenAttack = enemy.attacks[num];
        Debug.Log(this.gameObject.name + " has choosen " + myAttack.choosenAttack.attackName + (" and do ") + myAttack.choosenAttack.attackDamage + " damage! ");
        
        BSM.CollectActions (myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        //animate the enemy near the hero to attack
        Vector3 heroPosition = new Vector3(HeroToAttack.transform.position.x - 1.5f, HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        while(MoveTowardsEnemy(heroPosition)){yield return null;}

        //wait abit
        yield return new WaitForSeconds(0.5f);
        //do damage
        DoDamage();
        //animate back to startposition
        Vector3 firstPosition = startposition;
        while (MoveTowardsStart (firstPosition)) { yield return null; }


        //remove this performer from the list in BSM
        BSM.PerformList.RemoveAt (0);
        // reset BSM -> WAIT
        BSM.battleStates = BattleStateMaschine.PerformAction.WAIT;
        //end coroutine
        actionStarted = false;
        // reset this enemy state
        cur_cooldown = 0f;
        currentState = TurnState.PROCESSING;
    }

    private bool MoveTowardsEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    private bool MoveTowardsStart(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    void DoDamage()
    {
        float calc_damage = enemy.curATK + BSM.PerformList[0].choosenAttack.attackDamage;
        HeroToAttack.GetComponent<HeroStateMaschine>().TakeDamage(calc_damage);
    }
}
