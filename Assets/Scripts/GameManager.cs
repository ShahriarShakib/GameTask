using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameWinPanel;
    public GameObject gameOverPanel;
    
    public int scoreCount;
    public int playerHealth = 10;
    public int winScore;
    public int overScore;

    public TextMeshProUGUI scoreCountText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI winScoreText;
    public TextMeshProUGUI overScoreText;

    public static GameManager instance;
    private void Awake()
    {
        if(gameObject == null)
        {
            instance = this;
        }
        else
        {
            instance = this;
        }
    }
    public void OnclickReplayButton()
    {
        SceneManager.LoadScene(0);
        HidePanels();

    }
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(0);
        HidePanels();
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void HidePanels()
    {
        gameWinPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    public void ShowWinPanel()
    {
        HidePanels();
        gameWinPanel.SetActive(true);
    }
    public void ShowGameOverPanel()
    {
        HidePanels();
        gameOverPanel.SetActive(true);
    }
}
