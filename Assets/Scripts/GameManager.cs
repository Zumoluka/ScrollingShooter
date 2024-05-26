using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public float respawnDelay = 2f;
    public RawImage img;
    public Canvas canvas;
    private int score = 0;
    private bool gameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Canvas canvas = img.GetComponent<Canvas>();
        if(canvas != null)
        {
            canvas.sortingOrder = -1;
        }
        img.transform.SetAsFirstSibling();
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
    }

    public void RespawnPlayer()
    {
        gameOverText.gameObject.SetActive(false);
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

}
