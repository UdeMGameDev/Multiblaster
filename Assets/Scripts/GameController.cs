using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;




public class GameController : MonoBehaviour {

    public int waveCount = 0;
    public GameObject[] hazards;
    public GameObject[] items;

    public Wave[] waves;

    public Vector2 spawnValues;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text quitText;
    public Text readyText;
    public Text warningText;

    private bool gameOver;
    private bool restart;

    private int score;

    public float startWait = 1f;
    public float flickerWait; //Time between flickers of text
    public int flickerNumber; //Number of flickers

    public FloatReference hostHealth;
    public FloatReference shipHealth;

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
        warningText.text = ("");


        score = 0;

        InitializeVariables();

        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnRedBloodCells());
        StartCoroutine(SpawnItems());
    }

    private void Update()
    {
        //Debug.Log(shipHealth.value);
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

        
            Wave currentWave = GenerateWave(waveCount);
        

            if (!currentWave.noEnemies) StartCoroutine(Flicker(warningText, "Prepare to fire!", 4));

            yield return new WaitForSeconds(startWait + flickerWait * flickerNumber); //To wait for the player to mentally prepare

            for (int j = 0; j < currentWave.enemyCount; j++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                GameObject enemy = currentWave.SpawnEnemy(spawnPosition);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(currentWave.spawnWait);

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
            yield return new WaitForSeconds(4f);

            waveCount += 1;

        }

        
    }

    private void InitializeVariables(){
        hostHealth.variable.Value = hostHealth.variable.maxValue;
        shipHealth.variable.Value = shipHealth.variable.maxValue;
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

    public Wave GenerateWave(int waveCount)
    {

        int enemyCount = 10 + waveCount + Random.Range(0, waveCount / 5);
        float spawnWait = -(0.30f * waveCount) + 2f;
        if (spawnWait < 0.5f)
        {
            spawnWait = 0.5f;
        }

        GameObject[] enemyTypes;

        bool noEnemies;
        if (spawnWait % 5 == 0)
        {
            noEnemies = true;
            enemyTypes = new GameObject[]{hazards[0]};
        }
        else
        {
            noEnemies = false;
            enemyTypes = GenerateEnemyTypes(waveCount);
        }


       return new Wave(enemyTypes, enemyCount, spawnWait, noEnemies);
       //return new Wave(enemyTypes, 25, 0.5f, false);
        
    }



    public GameObject[] GenerateEnemyTypes(int waveCount)
    {
        GameObject[] enemyTypes;

        if (waveCount % 3 == 0)
        {
            enemyTypes = new GameObject[]{hazards[1], hazards[2]};
        }
        else
        {
            enemyTypes = new GameObject[]{hazards[Random.Range(0,hazards.Length+1)]};
        }

        return enemyTypes;
    }

    IEnumerator SpawnRedBloodCells()
    {
        float startTime = Time.time;

        yield return new WaitForSeconds(startWait + flickerWait * flickerNumber);

        while(true)
        {
            float timeDiff = Time.time - startTime;

            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
            GameObject cell = hazards[0];
            Instantiate(cell, spawnPosition, Quaternion.identity);

            float spawnRate = -0.022f * timeDiff + 3;
            yield return new WaitForSeconds(Mathf.Clamp(spawnRate, 1f, 5f));
        }
        
    }

    IEnumerator SpawnItems()
    {
        yield return new WaitForSeconds(startWait + flickerWait * flickerNumber);

        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);

            yield return new WaitForSeconds(15f);
            int random = Random.Range(0, items.Length);
            Instantiate(items[random], spawnPosition, Quaternion.identity);
        }
    }
}
