using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private float max_cooldown = 5f;
    
    //this gameObject
    private Vector3 startposition;
    public GameObject Selector;

    //timeforaction stuff
    private bool actionStarted = false;
    public GameObject HeroToAttack;
    private float animSpeed = 10f;

    //alive
    private bool alive = true;

    //animator
    private Animator enemyAnimator;

    //camera control
    public Camera mainCamera;
    public Camera enemyCamera;
    public Camera heroCamera;
    
    public Slider healthEnemySlider;
    public ParticleSystem particlePrefab;
    public GameObject damageParticlesPrefab;
    

    void Start()
    {
        currentState = TurnState.PROCESSING;
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMaschine>();
        startposition = transform.position;

        enemyAnimator = GetComponent<Animator>();
        healthEnemySlider = FindSliderByName("SLD_hp_enemy");
    }


       public void Update()
    {
        Debug.Log (currentState);
            
        switch(currentState)
        {
            
            case (TurnState.PROCESSING):
                if (BSM.PerformList.Count > 0)
                {
                    currentState = TurnState.CHOOSEACTION;
                }

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
                if(!alive)
                {
                    return;
                }
                else
                {
                    //change tag of enemy
                    this.gameObject.tag = "DeadEnemy";
                    //not attackable by heros
                    BSM.EnemysInBattle.Remove(this.gameObject);
                    //disable the selector
                    Selector.SetActive(false);
                    enemyAnimator.SetTrigger("MorteTrigger");
                    //remove all inputs enemyattacks
                    if(BSM.EnemysInBattle.Count > 0)
                    {

                    
                        for(int i = 0; i<BSM.PerformList.Count; i++)
                        {
                            if (BSM.PerformList[i].AttackersGameObject ==  this.gameObject)
                            {
                                BSM.PerformList.Remove(BSM.PerformList[i]);
                            }
                            if (BSM.PerformList[i].AttackersTarget == this.gameObject)
                            {
                                BSM.PerformList[i].AttackersTarget = BSM.EnemysInBattle[Random.Range(0,BSM.EnemysInBattle.Count)];
                            }
                        }
                    }
                    //change the color to gray / play dead animation
                    //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(105, 105, 105, 255);
                    //set alive false
                    alive = false;
                    //reset enemy buttons
                    BSM.EnemyButtons();
                    //check alive
                    BSM.battleStates = BattleStateMaschine.PerformAction.CHECKALIVE;

                }
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
        if (BSM.HerosInBattle.Count > 0)
        {
            // Cria um objeto HandleTurn para representar a ação do inimigo
            HandleTurn myAttack = new HandleTurn();
            myAttack.Attacker = enemy.theName;
            myAttack.Type = "Enemy";
            myAttack.AttackersGameObject = this.gameObject;

            // Escolhe um herói aleatório como alvo
            myAttack.AttackersTarget = BSM.HerosInBattle[Random.Range(0, BSM.HerosInBattle.Count)];

            // Escolhe um ataque aleatório do inimigo
            int num = Random.Range(0, enemy.attacks.Count);
            myAttack.choosenAttack = enemy.attacks[num];
            Debug.Log(this.gameObject.name + " has chosen " + myAttack.choosenAttack.attackName + " and does " + myAttack.choosenAttack.attackDamage + " damage!");

            // Adiciona a ação à lista de ações no BattleStateMaschine
            BSM.CollectActions(myAttack);
        }
        else
        {
            // Se não houver heróis na batalha, retorna ao estado PROCESSING
            currentState = TurnState.PROCESSING;
        }
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;
        
        
        //trocar camera
        enemyCamera.gameObject.SetActive(true);
        heroCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(false);
        
        //faz animacao de ataque
        string attackAnimation = BSM.PerformList[0].choosenAttack.attackAnimation;
        enemyAnimator.Play(attackAnimation);
        
        Debug.Log("INICIO ANIMACAO INIMIGO ATAQUE");

        //animate the enemy near the hero to attack
        //Vector3 heroPosition = new Vector3(HeroToAttack.transform.position.x - 1.5f, HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        //while(MoveTowardsEnemy(heroPosition)){yield return null;}

        //wait abit
        yield return new WaitForSeconds(3f);
        DoDamage();
        
        //retorna animacao de idle
        enemyCamera.gameObject.SetActive(false);
        heroCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        Debug.Log("FIM ANIMACAO INIMIGO ATAQUE");
        
        //do damage
        
        yield return new WaitForSeconds(3f);

        //animate back to startposition
        //Vector3 firstPosition = startposition;
        //while (MoveTowardsStart (firstPosition)) { yield return null; }


        //remove this performer from the list in BSM
        BSM.PerformList.RemoveAt (0);
        // reset BSM -> WAIT
        BSM.battleStates = BattleStateMaschine.PerformAction.WAIT;
        //end coroutine
        actionStarted = false;
        // reset this enemy state
        cur_cooldown = 0f;
        currentState = TurnState.PROCESSING;
        BSM.turnCount++;
        BSM.turnCountText.text = "TURNO: " + BSM.turnCount.ToString();
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
        if (damageParticlesPrefab != null && HeroToAttack != null)
        {
            GameObject particles = Instantiate(damageParticlesPrefab, HeroToAttack.transform.position, Quaternion.identity);
            particles.GetComponent<ParticleSystem>().Play();
            Destroy(particles, particles.GetComponent<ParticleSystem>().main.duration);
        }
    }

    public void TakeDamake(float getDamageAmount)
    {
        enemy.curHP -= getDamageAmount;
        if(enemy.curHP <= 0)
        {
            enemy.curHP = 0;
            currentState = TurnState.DEAD;
        }
        if (healthEnemySlider != null)
        {
            UpdateHealthSlider();
        }
    }
    
    void UpdateHealthSlider()
    {
        if (healthEnemySlider != null)
        {
            // Atualiza o valor máximo do Slider com a saúde máxima do inimigo
            healthEnemySlider.maxValue = enemy.baseHP;

            // Atualiza o valor atual do Slider com a saúde atual do inimigo
            healthEnemySlider.value = enemy.curHP;
        }
    }
    Slider FindSliderByName(string sliderName)
    {
        // Procure por um objeto com o nome especificado
        GameObject sliderObject = GameObject.Find(sliderName);

        // Se o objeto for encontrado, tente obter o componente Slider
        if (sliderObject != null)
        {
            Slider sliderComponent = sliderObject.GetComponent<Slider>();
        
            // Se o componente Slider for encontrado, retorne-o
            if (sliderComponent != null)
            {
                return sliderComponent;
            }
            else
            {
                Debug.LogError("Componente Slider não encontrado no objeto " + sliderName);
            }
        }
        else
        {
            Debug.LogError("Objeto não encontrado com o nome " + sliderName);
        }

        // Se algo der errado, retorne null
        return null;
    }
}
