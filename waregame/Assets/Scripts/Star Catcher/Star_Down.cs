using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stared_Down : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D x)
    {
        if (x.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
