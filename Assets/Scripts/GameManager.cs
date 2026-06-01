using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public GameObject gameOverText;
    public GameObject restartButton;
    public TMP_Text scoreText;

    private float score;

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;

        gameOverText.SetActive(true);
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}