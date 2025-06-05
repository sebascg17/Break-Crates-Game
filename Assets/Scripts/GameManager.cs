using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public Button restartButton;
    public GameObject titleScreen;
    private int score;
    private float spawnRate = 1.0f; // Time in seconds between spawns

    public bool isGameActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {

    }
    void Update ()
    {

    }

    // Update is called once per frame

    public void UpdateScore ( int scoreToAdd )
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget ()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void GameOver ()
    {
        isGameActive = false;
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void StartGame (int difficulty)
    {
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0); // Initialize score to 0

        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
