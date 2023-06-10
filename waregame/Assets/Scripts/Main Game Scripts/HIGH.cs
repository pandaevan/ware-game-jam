using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class HIGH : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    // Start is called before the first frame update
public void Menu()
{
SceneManager.LoadScene(0);
}
    // Update is called once per frame
    void Update()
    {
        tmp.text = $"{PlayerPrefs.GetFloat("RunScore",0).ToString("F2")}";
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
