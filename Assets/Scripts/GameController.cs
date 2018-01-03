using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;




public class GameController : MonoBehaviour {

    public GameObject[] hazards;

    public Vector2 spawnValues;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text quitText;
    public Text readyText;

    private bool gameOver;
    private bool restart;

    private int score;

    public int hazardCount;
    public float spawnWait; //Time between spawns
    public float startWait; //Time before the game starts
    public float waveWait; //Time between waves
    public float flickerWait; //Time between flickers of text
    public int flickerNumber; //Number of flickers


    IEnumerator Flicker (Text textObj, string text, int flickerNumber = 4, bool loop = false)
    {
        bool Switch = false;
        for (int i = 0; i < flickerNumber; i++)
        {
            if (Switch == true)
            {
				textObj.text = ("");
                Switch = false;
            }
            else
            {
				textObj.text = text;
                Switch = true;
            }
            if (loop){
                i--; //retourne en arrière
            }
            yield return new WaitForSeconds(flickerWait);
        }
    }

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = ("");
        gameOverText.text = ("");
        quitText.text = ("");
        readyText.text = ("");

        score = 0;

            StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Press Escape to quit at any time
        {
            Application.Quit();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //load à nouveau la même scène
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        StartCoroutine(Flicker(readyText, "Get ready!", flickerNumber)); //Get ready flicker

        yield return new WaitForSeconds(startWait + flickerWait * flickerNumber); //To wait for the player to mentally prepare
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
				Instantiate(hazard, spawnPosition, Quaternion.identity); //identity == aucune rotation
                yield return new WaitForSeconds(spawnWait);
            

            if (gameOver)
                {
                    restartText.text = ("Press R to restart");
                    quitText.text = ("Press Escape to quit");
                    restart = true;
                    StartCoroutine(Flicker(restartText, "Press R to restart", 2, loop:true));
                    StartCoroutine(Flicker(quitText, "Press Escape to quit", 2, loop:true));
                    break;
                }
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void UpdateScore() //To update the score on the GUI text
    {
        scoreText.text = "Score " + score;
    }

    public void AddScore(int newScoreValue) //Used in DestroyByContact.cs
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = ("Game Over!");
        gameOver = true;
    }
}
