using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Ui : MonoBehaviour
{
    public manager manager;
public void quit()
{
    Application.Quit();
}
public void Resume()
{
manager.pause.SetActive(false);
manager.MainUi.SetActive(true);
manager.Ani.enabled = true;
Time.timeScale = 1;
}
public void MainMenu()
{
    SceneManager.LoadScene(0);
}
}
