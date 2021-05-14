using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelsScene = "LevelSelect";
    public string aboutScene = "About";
    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo(levelsScene);
    }
    public void About()
    {
        SceneManager.LoadScene(aboutScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}