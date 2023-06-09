using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrack : MonoBehaviour
{
public float Score = 0;
public void FixedUpdate()
{
    Score += Time.deltaTime;;
}
}
