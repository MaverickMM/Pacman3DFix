using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Nama scene yang akan dituju
    public string NamaScene;

    // Fungsi yang akan dipanggil saat tombol ditekan
    public void ChangeScene()
    {
        SceneManager.LoadScene(NamaScene);
    }
    
    public void Quitgame()
    {
        Application.Quit();
    }

}
