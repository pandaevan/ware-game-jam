using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
        public void credits()
    {
        SceneManager.LoadScene(2);
    }
    

    public void QuitGame()
    {
        Application.Quit();
        print("Quiting...");
    }
}
