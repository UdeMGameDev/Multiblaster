using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave {

	public GameObject[] enemies;
	public int enemyCount;
	private int enemiesRemaining; //may or may not display on screen
	//private int requiredForNext; //may or may not be used at all...

	public float spawnWait;

	public bool noEnemies;
	

	public Wave(GameObject[] enemyTypes, int enemyCount, float spawnWait, bool noEnemies)
	{
		this.enemies = enemyTypes;
		this.enemyCount = enemyCount;
		this.spawnWait = spawnWait;
		this.noEnemies = noEnemies;
		this.enemiesRemaining = enemies.Length;
	}


 	public GameObject SpawnEnemy(Vector2 position) {
		GameObject enemy = enemies[Random.Range(0, enemies.Length)];
		return enemy;
	}

}
