using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrack : MonoBehaviour
{
public int Score = 0;
public void FixedUpdate()
{
    Score = Score + 1;
}
}
