using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameManager gm;
    public void startAndRestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("InGame");
    }
    public void exit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void emergency()
    {
        gm.timeLimit = 1;
    }
}
