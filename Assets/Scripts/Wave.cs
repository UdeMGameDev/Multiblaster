using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public GameObject[] enemies;
	public int enemyCount;
	private int enemiesRemaining; //may or may not display on screen
	//private int requiredForNext; //may or may not be used at all...

	public float spawnWait = 1;

	public bool enemyOnly = false;
	


	// Use this for initialization
	void Start () {
		enemiesRemaining = enemies.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 	public void SpawnEnemy(Vector2 position){
		GameObject enemy = enemies[Random.Range(0, enemies.Length)];
		Instantiate(enemy, position, Quaternion.identity); //identity == aucune rotation
	}

}
