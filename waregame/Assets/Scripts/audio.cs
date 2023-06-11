using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audio : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "CutScene")
        {
        Destroy(gameObject);
        }

    }
}
