using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
 [Header("Boss Spawn Time")]
 public int BossTimeMin;
 public int BossTimeMax;
 public int BossLengthMin;
 public int BossLenghtMax; 
 public int BossActiveResetTimer;
 [Header("Values")]
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
      isworking = true;
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
            MainManager.SetActive(false);
            BossMan.SetActive(false);
            MainUi.SetActive(false);
            Ani.enabled = false;
        }
        
      }
      IEnumerator Bossloop()
      {
        while(true)
        {
            bossspawntimer = Random.Range(BossTimeMin , BossTimeMax);
            BossActiveResetTimer = Random.Range(BossLengthMin , BossLenghtMax);
            //spawns boss
            yield return new WaitForSeconds(bossspawntimer);
            BossMan.SetActive(true);
            iswatching = true;
            yield return new WaitForSeconds(BossActiveResetTimer);
            BossMan.SetActive(false);
            iswatching = false;
        }
      }
}
