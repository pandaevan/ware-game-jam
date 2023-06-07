using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
  [SerializeField] public float exposure;
  public float boredom;
  public float currentexposure;
  public float currentboredom;
  public float attentionspan;
  public float bpm;
  public bool isworking;
  public bool iswatching;
  public Slider bored;
  public int bossspawntimer;
  public bool BossTimerSet;
  public float timePassed;
  [SerializeField] public SpriteRenderer MC;

    // Start is called before the first frame update
    void Start()
    {
      boredom = currentboredom;
      bored.minValue = boredom;
    }

    // Update is called once per frame
    void Update()
    {
        bored.value = currentboredom;
        BossActiveResetTimer();
        bossrange();
        IsWorkingToggle();
        AttentionSpan();
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
            isworking = !isworking;
            MC.enabled = !isworking;
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
}
