using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public bool Finished_1;
    public bool Finished_2;
    public bool Finished_3;

    void Start()
    {
        Finished_1 = false;
        Finished_2 = false;
        Finished_3 = false;
    }
    public void AniDelay()
    {
        Finished_1 = true;
    }

    public void AniDelay_1()
    {
        Finished_2 = true;
    }

    public void AniDelay_2()
    {
        Finished_3 = true;
    }

}
