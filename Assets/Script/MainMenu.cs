using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Fungsi yang akan dipanggil saat tombol ditekan
    public void Menu()
    {
        SceneManager.LoadScene("Envi");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }

}