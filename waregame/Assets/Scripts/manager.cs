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

    private void BossActiveResetTimer()
    {
        timePassed += Time.deltaTime;
        if (timePassed > bossspawntimer)
        {
            timePassed = 0;
            bruv();
        }
    }

    private void IsWorkingToggle()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isworking = !isworking;
            MC.enabled = !isworking;
        }
    }
    public void bossrange()
    {
      if(BossTimerSet == false)
      {
        bossspawntimer = Random.Range(10,30);
        Debug.Log(BossTimerSet);
        BossTimerSet = true;
      }
    }
          public void bruv()
      {
       Debug.Log("active");
       BossTimerSet = false;
      }
}
