using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
  [SerializeField] public float exposure;
  public float boredom;
  public float currentexposure;
  public float currentboredom;
  public float attentionspan;
  public float bpm;
  public Slider bored;
  public int bossspawntimer;
  public bool BossTimerSet;
  public float timePassed;
  public Animator Ani; //Animator
public bool isworking;
  public bool iswatching;

    // Start is called before the first frame update
    void Start()
    {
      boredom = currentboredom;
      bored.minValue = boredom;
      isworking = true;
    }

    // Update is called once per frame
    void Update()
    {
        bored.value = currentboredom;
        BossActiveResetTimer();
        bossrange();
        IsWorkingToggle();
        AttentionSpan();
        playerbored();
    }

// manages the attentionspan (how quickly the boredom meter fills)
    private void AttentionSpan()
    {
        if (isworking && !iswatching)
        {
            currentboredom += attentionspan * Time.deltaTime;
        }
        if (!isworking)
        {
            if (currentboredom >= 0)
            {
                currentboredom -= attentionspan * Time.deltaTime;
            }
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
      }
      public void ketbinds()
      {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
      }
}
