using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
  public float exposure;
  public float boredom;
  public float currentexposure;
  public float currentboredom;
  public float attentionspan;
  public float bpm;
  public bool isworking;
  public bool iswatching;
  public Slider bored;
  public int bossspawntimer;
  public bool bossactive;
  public float timePassed;

    // Start is called before the first frame update
    void Start()
    {
      boredom = currentboredom;
      bored.minValue = boredom;
    }

    // Update is called once per frame
    void Update()
    { 
      
       timePassed += Time.deltaTime;
    if(timePassed > bossspawntimer)
    {
        timePassed = 0;
        bruv();
    } 
      bossrange();
      bored.value = currentboredom;
        IsWorkingToggle();
        if (isworking && !iswatching)
        {
          currentboredom += attentionspan * Time.deltaTime;
        }
       if (!isworking)
        {
        if(currentboredom >= 0)
      {
        currentboredom -= attentionspan * Time.deltaTime;
      }
        }
    }

    private void IsWorkingToggle()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isworking = !isworking;
        }
    }
    public void bossrange()
    {
      if(bossactive == false)
      {
        bossspawntimer = Random.Range(10,30);
        bossactive = !bossactive;
        Debug.Log(bossactive);
      }
    }
          public void bruv()
      {
       Debug.Log("active");
       bossactive = false;
      }
}
