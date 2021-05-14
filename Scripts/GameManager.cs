using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject levelWinUI;
    private void Start()
    {
        GameIsOver = false;
    }
    private void Update()
    {
        if (GameIsOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    public void WinLevel()
    {
        levelWinUI.SetActive(true);
    }
    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}