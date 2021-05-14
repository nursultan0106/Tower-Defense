using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    public string nextLevelName = "Level2";
    public int levelToReach = 2;
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToReach);
        sceneFader.FadeTo(nextLevelName);
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}