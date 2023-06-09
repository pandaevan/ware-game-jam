using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Movment : MonoBehaviour
{
float horizontal;

public int Speed = 20;
public Rigidbody2D body;

void Update ()
{
   horizontal = Input.GetAxisRaw("Horizontal");
}

private void FixedUpdate()
{  
   body.velocity = new Vector2(horizontal * Speed, body.velocity.y);
}
}