using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scorepoint : MonoBehaviour
{
    // Start is called before the first frame update

    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "  POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("abc");
    }

    public void Menu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}