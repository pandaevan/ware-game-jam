using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement
 : MonoBehaviour
{
    [Header("Movement Values")]
public Rigidbody2D Body;
public int Speed;
public float RocketPower;
public float jump;
private float Horizontal;
private float Vertical;
public bool isjumping;
public float jumptime;
public float jumpcounter;
    [Header("GroundCheck values")]
public Vector3 BoxSize;
public float MaxGroundDistance; 
public LayerMask layerMask;
    [Header("Rocket Values")]
public float fuel;
public float MaxFuel;
public Slider fuelbar;
public float dValue;
public float iValue;

public void Start() 
{
    MaxFuel = fuel;
    fuelbar.maxValue = MaxFuel;
}
public void decreasefuel()
{
if(fuel!= 0)
    fuel -= dValue * Time.deltaTime;
}
public void increasefuel()
{
    fuel += iValue * Time.deltaTime;
}

public bool GroundCheck()
    {
        if(Physics2D.BoxCast(transform.position,BoxSize,0,-transform.up,MaxGroundDistance,layerMask))
        {
            return true;
        }
        {
            return false;
        }
    }
    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        fuelbar.value = fuel;
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
            if(Input.GetButtonDown("Jump") && GroundCheck() == true)
        {
            Jump();

        }

                if(Input.GetButtonUp("Jump") && Body.velocity.y > 0)
        {
            Body.velocity = new Vector2(Body.velocity.x, Body.velocity.y * .5f);
        }
        if(Input.GetButton("Jump") && jumpcounter < 2 && fuel > 0)
        {
            Rocket();
            decreasefuel();
        }
        if(GroundCheck())
        {
            jumpcounter = jumptime;
        }
        else
        {
            jumpcounter -= Time.deltaTime;
        }
    }
    public void Jump()
    {
    Body.AddForce(new Vector2(Body.velocity.x, jump));
    }
    public void FixedUpdate()
    {
        Body.velocity = new Vector2(Horizontal * Speed, Body.velocity.y);
        if(fuel <= MaxFuel && GroundCheck())
        {
            increasefuel();
        }
        else
        {
            
        }
    }

    public void Rocket()
    {
        Body.velocity = Body.velocity + Vector2.up * RocketPower * Time.deltaTime;
    }
    void OnDrawGizmos() 
    {
        if(GroundCheck())
        {
        Gizmos.color=Color.green;
        }
        else
        {
        Gizmos.color=Color.red;
        }
    Gizmos.DrawCube(transform.position-transform.up * MaxGroundDistance,BoxSize);    
    }
}