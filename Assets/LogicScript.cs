using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{

    public float normalSpeed = 10f;
    public float boostSpeed = 30f;
    public float boostDuration = 0.2f;
    public float transitionDuration = 0.1f;

    public float gameSpeed;
    private float boostTimer;
    private bool isBoosting;
    private bool isReturning;

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverPanel;

    [ContextMenu("addScore")]
    public void AddScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {
        gameSpeed = 0;
        gameOverPanel.SetActive(true);
    }


    void Update()
    {

        if (isBoosting)
        {
            boostTimer += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, boostTimer / transitionDuration);
            gameSpeed = Mathf.Lerp(normalSpeed, boostSpeed, t);

            if (boostTimer >= boostDuration)
            {
                isBoosting = false;
                isReturning = true;
                boostTimer = 0;
            }
        }
        else if (isReturning)
        {
            boostTimer += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, boostTimer / transitionDuration);
            gameSpeed = Mathf.Lerp(boostSpeed, normalSpeed, t);

            if (boostTimer >= transitionDuration)
            {
                isReturning = false;
                gameSpeed = normalSpeed;
            }
        }

        // Apply the game speed to your moving objects
        // For example: background.transform.Translate(Vector3.left * gameSpeed * Time.deltaTime);
    }


    [ContextMenu("StartBoost")]
    public void StartBoost()
    {
        isBoosting = true;
        boostTimer = 0;
    }

};
