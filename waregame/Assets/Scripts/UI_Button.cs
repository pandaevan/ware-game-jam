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
        SceneManager.LoadScene(3);
    }

        public void Options()
    {
        SceneManager.LoadScene(4);
    }    
        public void HowToPlay()
    {
        SceneManager.LoadScene(5);
    }    

        public void back()
    {
        SceneManager.LoadScene(0);
    }    

    public void QuitGame()
    {
        Application.Quit();
        print("Quiting...");
    }
}
