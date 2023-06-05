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
}
