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
        Invoke(nameof(StartSpawning), 5f);
    }

    // Method to start the spawning process
    private void StartSpawning()
    {
        if (pipeSpawnScript != null)
        {
            pipeSpawnScript.StartSpawning();
            gameStart.SetActive(false);
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    private void OnDestroy()
    {
       
    }
}