using UnityEngine;

public class AboutMenu : MonoBehaviour
{
    public string backScene = "MainMenu";
    public SceneFader sceneFader;
    public void Back()
    {
        sceneFader.FadeTo(backScene);
    }
}