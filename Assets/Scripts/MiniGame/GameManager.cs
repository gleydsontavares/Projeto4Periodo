using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public Slider slider;
    public GameObject SeuBotaoNaUI;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject pressKeyDown;
    public GameObject resultsScreen;
    public GameObject txtCombo;
    public GameObject txtScore;
    public GameObject sliderDuration;
    public GameObject txtSlider;
    public GameObject txtFailed;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;

        slider.maxValue = theMusic.clip.length;

    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        { 
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();

            }
        }
        else
        {
            if(startPlaying && !theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                txtCombo.SetActive(false);
                txtScore.SetActive(false);
                sliderDuration.SetActive(false);
                txtSlider.SetActive(false);
                resultsScreen.SetActive(true);

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if(percentHit > 40)
                {
                    rankVal = "D";
                    if(percentHit > 55)
                    {
                        rankVal = "C";
                        if(percentHit > 70)
                        {
                            rankVal = "B";
                            if(percentHit > 80)
                            {
                                rankVal = "A";
                                if(percentHit > 90)
                                {
                                    rankVal = "S";
                                    if(percentHit > 99)
                                    {
                                        rankVal = "PERFECT";
                                    }
                                }
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();

                if (percentHit > 80)
                {
                    // Ativar o bot�o na UI
                    SeuBotaoNaUI.SetActive(true);
                    txtFailed.SetActive(false);
                }
                else
                {
                    // Desativar o bot�o na UI
                    SeuBotaoNaUI.SetActive(false);
                    txtFailed.SetActive(true);
                }
            }
        }
        
        if (startPlaying)
        {
            slider.value = theMusic.time;
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if(currentMultiplier -1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "x" + currentMultiplier;


        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "" + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }
    
    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "" + currentMultiplier;

        missedHits++;
    }
}
