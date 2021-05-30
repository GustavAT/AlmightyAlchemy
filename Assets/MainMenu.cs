using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void OptionsMenu()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
}