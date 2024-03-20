using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject bird;
    public GameObject gameStart;
    public GameObject stopScreen;
    public GameObject gameResume;
    public Text countdownText;
    PipeSpawnScript pipeSpawnScript;
 
    [ContextMenu("Increase Score")]

    void Start()
    {
        pipeSpawnScript = (PipeSpawnScript)FindObjectOfType(typeof(PipeSpawnScript));
        Debug.Log(pipeSpawnScript);

    }
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void startGame()
    {
        gameStart.SetActive(false);
        stopScreen.SetActive(true); 
        // Invoke(nameof(StartSpawning), 5f);
        StartCoroutine(Countdown());
    }

    // Method to start the spawning process
    private void StartSpawning()
    {
        if (pipeSpawnScript != null)
        {
            pipeSpawnScript.StartSpawning();
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    public void gameOver()
    {
        stopScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void stopGame()
    {
       if (pipeSpawnScript != null)
        {
            pipeSpawnScript.StopSpawning();
            stopScreen.SetActive(false);
            gameResume.SetActive(true);

        } 

    }
    public void resumeGame()
    {
       if (pipeSpawnScript != null)
        {
            StartCoroutine(Countdown());
            gameResume.SetActive(false);
            // pipeSpawnScript.StartSpawning();
            stopScreen.SetActive(true);
        } 

    }
    IEnumerator Countdown()
    {
        int count = 3;
        while (count > 0)
        {
            // Debug.Log(Time.timeScale);
            countdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f); 
            count--;
        }
        countdownText.text = ""; 
        StartSpawning();
    }


}