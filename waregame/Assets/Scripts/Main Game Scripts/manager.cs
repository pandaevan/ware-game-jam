using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class manager : MonoBehaviour
{
 [Header("Bosses")]
 public Animator Boss_1;
 public Animator Boss_2;
 public Animator Special_Boss;
 public int trio;
 [Header("Boss_Animation")]
public Boss_1_Script AnimScript;
public Boss_2_Script AnimScript_1;
public Boss_3_anim AnimScript_2;
 [Header("Boss Spawn Time")]
 public int BossTimeMin;
 public int BossTimeMax;
 public int BossLengthMin;
 public int BossLenghtMax; 
 public int BossActiveResetTimer;
 [Header("Values")]
 public float DifficultyMult;
  public float currentexposure;
  public float currentboredom;
  public float attentionspan;
  public float retentionspan;
  public float exposurespeed;
  public float oblivious;
  public int bossspawntimer;
  [Header("bools")]
  public bool isworking;
  public bool iswatching;
  public bool IsExposed;
  public bool difficultjump;
  public bool difficultjump2;
  public bool difficultjump3;
  public bool difficultjump4;
  [Header("References")]
  public Slider bored;
  public Slider exposed;
  public Animator Ani; 
  public GameObject pause;
  public GameObject MainManager;
  public GameObject MainUi;
    // Start is called before the first frame update
    void Start()
    {
      isworking = true;
    }
     void Awake()
    {
                StartCoroutine(Bossloop());
    }
    // Update is called once per frame
    void Update()
    {
        bored.value = currentboredom;
        exposed.value = currentexposure;
        IsWorkingToggle();
        AttentionSpan();
        playerbored();
        keybinds();
        Exposed();
        if(currentexposure >= 100)
        {
            Ani.SetBool("IsDying" ,true);
            Invoke("Deathsecuence", 3f);
        }
    }
    public void FixedUpdate() 
    {
        if(DifficultyMult <= .4 )
        DifficultyMult += Time.deltaTime * 0.0005f;
        if(DifficultyMult >= .1 && difficultjump == false)
        {
            BossTimeMin = 9;
            BossTimeMax = 25;
            BossLengthMin = 8;
            BossLenghtMax = 14; 
            difficultjump = true;
            attentionspan =22;
            retentionspan =14;
            exposurespeed =15 ;
            oblivious =9;
        }
                if(DifficultyMult >= .2 && difficultjump2 == false)
        {
            BossTimeMin = 8;
            BossTimeMax = 20;
            BossLengthMin = 10;
            BossLenghtMax = 16; 
            difficultjump2 = true;
            attentionspan =23;
            retentionspan =13;
            exposurespeed =16 ;
            oblivious =8;
        }
                if(DifficultyMult >= .3 && difficultjump3 == false)
        {
            BossTimeMin = 7;
            BossTimeMax = 15;
            BossLengthMin = 12;
            BossLenghtMax = 18; 
            difficultjump3 = true;
        }
                if(DifficultyMult >= .4 && difficultjump4 == false)
        {
            BossTimeMin = 7;
            BossTimeMax = 14;
            BossLengthMin = 14;
            BossLenghtMax = 20; 
            difficultjump4 = true;
        }
    }
// manages the attentionspan (how quickly the boredom meter fills)
    private void AttentionSpan()
    {
        if (isworking)
        {
            currentboredom += attentionspan * Time.deltaTime;
        }
        if (!isworking)
        {
            if (currentboredom >= 0)
            {
                currentboredom -= retentionspan * Time.deltaTime;
            }
        }
    }
    public void Exposed()
    {
        if(!isworking && iswatching)
        {
             currentexposure += exposurespeed * Time.deltaTime;
        }
        if(isworking && !iswatching && currentexposure >= 0)
        {
            currentexposure -= oblivious * Time.deltaTime;
        }
    }
    public void playerbored()
    {
        if(currentboredom >= 100)
        {
            Ani.SetBool("IsDying" ,true);
            Invoke("Deathsecuence", 3f);
        }
    }
    public void Deathsecuence()
    {
        SceneManager.LoadScene(2);
    }
// toggles the is working bool and also toggles the sprite of the player
    private void IsWorkingToggle()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isworking == true)
            {
                isworking = !isworking;
                Ani.SetBool("IsWorking",false);
            }
            else if (isworking == false)
            {
                isworking = true;
                Ani.SetBool("IsWorking",true);
            }
        }
    }
      public void keybinds()
      {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            MainUi.SetActive(false);
            Ani.enabled = false;
            Time.timeScale = 0;
        }
        

      }
        public void bubby()
        {
            iswatching = true;
        }
      IEnumerator Bossloop()
      {
        while(true)
        {
            bossspawntimer = Random.Range(BossTimeMin , BossTimeMax);
            BossActiveResetTimer = Random.Range(BossLengthMin , BossLenghtMax);
            trio = Random.Range(1,4); Debug.Log(trio);
            //spawns boss
            yield return new WaitForSeconds(bossspawntimer);
            if(trio == 1)
            {
                
                Boss_1.SetBool("IsHere" , true);
                if (Boss_1 == true)
                {
                    Invoke("bubby", 1);
                }
            }
            if(trio == 2)
            {
                Boss_2.SetBool("Approach" , true);
                if (Boss_2 == true)
                {
                    Invoke("bubby", 1);
                }
            }
            if(trio == 3)
            {
                Special_Boss.SetBool("WalkingIn" , true);
                if (Special_Boss == true)
                {
                    Invoke("bubby", 1);
                }
            }
            yield return new WaitForSeconds(BossActiveResetTimer);
            if(trio == 1)
            {
                iswatching = false;
                Boss_1.SetBool("IsHere", false);
                Boss_1.SetBool("Stops" , true);
            }
            if(trio == 2)
            {
                iswatching = false;
                Boss_2.SetBool("Approach", false);
                Boss_2.SetBool("Boss_Leave" , true);
            }
            if(trio == 3)
            {
                iswatching = false;
                Special_Boss.SetBool("WalkingIn", false);
                Special_Boss.SetBool("Leave" , true);
            }
            yield return new WaitForSeconds(1);
            Boss_1.SetBool("Stops" , false);
            Boss_2.SetBool("Boss_Leave" , false);
            Special_Boss.SetBool("Leave", false);
        }
      }
}
