using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject menu;
    public GameObject menu1;
    public GameObject next;
public void main()
{
    menu1.SetActive(true);
    menu.SetActive(false);
}
public void main1()
{
    menu.SetActive(true);
    menu1.SetActive(false);
}
public void main2()
{
    next.SetActive(true);
    menu1.SetActive(false);
}
public void main3()
{
    next.SetActive(false);
    menu1.SetActive(true);
}
}
