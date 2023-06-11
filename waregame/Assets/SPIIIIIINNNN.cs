using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPIIIIIINNNN : MonoBehaviour
{
void Update()
    {
        gameObject.transform.Rotate(Vector3.up,360 * Time.deltaTime);
        gameObject.transform.Rotate(Vector3.right,360 * Time.deltaTime);
        gameObject.transform.Rotate(Vector3.forward, 160 * Time.deltaTime);
    }
}
