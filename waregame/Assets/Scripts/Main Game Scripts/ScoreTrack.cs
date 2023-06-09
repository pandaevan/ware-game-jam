using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrack : MonoBehaviour
{
    private void Start() 
    { 
    }
public float Score = 0;
public void FixedUpdate()
{
    Score += Time.deltaTime;;
}
public void Update()
    {
        CheckHS();
        PlayerPrefs.SetFloat("RunScore",Score);
    }


    public void CheckHS()
    {
    if(Score > PlayerPrefs.GetFloat("HighScore",0))
    {
        PlayerPrefs.SetFloat("HighScore",Score);
    }    
    }
}
