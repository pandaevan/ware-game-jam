using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Down : MonoBehaviour
{
    public string play = "Player";
void Update()
{
    if (gameObject.transform.position.y < -4)
    {
        Destroy(gameObject);
        print("GameOver");
    }
    
}
public void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag(play))
    {
    Destroy(gameObject); 
    print("finally");
    }
}

}
