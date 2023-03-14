using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
   


    public void RestartButton()
    {
        SceneManager.LoadScene("Envi");
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}