using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public manager Manager;
    public bool Finished_1;
    public bool Finished_2;
    public bool Finished_3;

    void Start()
    {
        Debug.Log("no watch");
        Finished_1 = false;
    }
    public void AniDelay()
    {
        Finished_1 = true;
        Debug.Log("watch");
        Manager.iswatching = true;
    }

}
