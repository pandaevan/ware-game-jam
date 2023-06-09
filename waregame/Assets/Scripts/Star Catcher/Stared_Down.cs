using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Down : MonoBehaviour
{
void Update()
{
    if (gameObject.transform.position.y < -4)
    {
        Destroy(gameObject);
        print("GameOver");
    }
    
}
void OnCollisionEnter2D(Collision2D collision)
{
    Destroy(gameObject); 
    print("finally");
}
}
