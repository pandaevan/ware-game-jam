using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
 [Header("Values")]
  public float exposure;
  public float boredom;
  public float currentexposure;
  public float currentboredom;
  public float attentionspan;
  public float retentionspan;
  public float exposurespeed;
  public float oblivious;
  public float bpm;
  public int bossspawntimer;
  public float timePassed;
  [Header("bools")]
  public bool isworking;
  public bool iswatching;
  public bool BossTimerSet;
  public bool IsExposed;
  [Header("References")]
  public Slider bored;
  public Slider exposed;
  public Animator Ani; 
  public GameObject pause;
  public GameObject MainManager;
  public GameObject BossMan;
  public GameObject MainUi;
    // Start is called before the first frame update
    void Start()
    {
      boredom = currentboredom;
      bored.minValue = boredom;
      exposure = currentexposure;
      exposed.minValue = exposure;
      isworking = true;
    }

    // Update is called once per frame
    void Update()
    {
        bored.value = currentboredom;
        exposed.value = currentexposure;
        //BossActiveResetTimer();
        //bossrange();
        IsWorkingToggle();
        AttentionSpan();
        playerbored();
        keybinds();
        Exposed();
        if(iswatching == true)
        {
            BossMan.SetActive(true);
        }
        else
        {
            BossMan.SetActive(false);
        }
        if(currentexposure == 100)
        {
            Ani.SetBool("IsDying" ,true);
            Invoke("Deathsecuence", 3f);
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
        if(isworking && currentexposure >= 0)
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
// sees if the time passed is the same as the random time and then executes the code
    private void BossActiveResetTimer()
    {
        timePassed += Time.deltaTime;
        if (timePassed > bossspawntimer)
        {
            timePassed = 0;
            BossTimerReset();
        }
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
    //randomly generates a number between a range
    public void bossrange()
    {
      if(BossTimerSet == false)
      {
        bossspawntimer = Random.Range(10,30);
        Debug.Log(BossTimerSet);
        BossTimerSet = true;
      }
    }
    // works to reset the boss timer
          public void BossTimerReset()
      {
       Debug.Log("active");
       BossTimerSet = false;
       iswatching = true;
      }
      public void keybinds()
      {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            MainManager.SetActive(false);
            BossMan.SetActive(false);
            MainUi.SetActive(false);
            Ani.enabled = false;
        }
      }
}
