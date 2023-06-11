using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
public GameObject One;
public GameObject Two;
public GameObject Three;
public GameObject T;

void Start()
{
    One.SetActive(true);
    Two.SetActive(false);
    Three.SetActive(false);
    T.SetActive(false);

    StartCoroutine(Transition());
}


IEnumerator Transition()
{
    yield return new WaitForSeconds(7);
    T.SetActive(true);
    yield return new WaitForSeconds(0.3f);
    T.SetActive(false);
    One.SetActive(false);
    Two.SetActive(true);
    yield return new WaitForSeconds(6);
    T.SetActive(true);
    yield return new WaitForSeconds(0.3f);
    T.SetActive(false);
    Two.SetActive(false);
    Three.SetActive(true);
    yield return new WaitForSeconds(8);
    T.SetActive(true);
    yield return new WaitForSeconds(0.3f);
    SceneManager.LoadScene(1);

}
}