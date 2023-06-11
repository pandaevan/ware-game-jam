using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript2 : MonoBehaviour
{
    public manager Manager;
    public bool Finished_3;

    void Start()
    {
        Debug.Log("no watch");
        Finished_3 = false;
    }
    public void AniDelay_2()
    {
        Finished_3 = true;
        Debug.Log("watch");
        Manager.iswatching = true;
    }
}
