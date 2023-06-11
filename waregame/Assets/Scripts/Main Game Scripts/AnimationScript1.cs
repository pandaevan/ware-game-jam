using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript1 : MonoBehaviour
{
    public manager Manager;
    public bool Finished_2;

    void Start()
    {
        Debug.Log("no watch");
        Finished_2 = false;
    }
    public void AniDelay_1()
    {
        Finished_2 = true;
        Debug.Log("watch");
        Manager.iswatching = true;
    }
}
