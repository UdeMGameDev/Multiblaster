using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController; //GameController == Class, gameController == one instance of the class

    public int scoreValue;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); //Finds the Game Controller object, if any, for each instantiation of the enemy
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy") //To avoid collision between enemies
        {
            return;
        }
        //ce bout de code est dégueu, à changer (c'est moi qui l'a écrit) ;) - Rémy
        if ((CompareTag("PlayerShot") || CompareTag("EnemyShot")) && other.CompareTag("PlayerShot") ){
            return;
        }
        if (other.CompareTag("EnemyShot"))
        {
            if (CompareTag("PlayerShot") || CompareTag("EnemyShot")){
                return;
            }
            if (CompareTag("Enemy")){
                return;
            }
        }

        if (explosion != null)
            {
            Instantiate(explosion, transform.position, transform.rotation); //Asteroid explosion
            }

        //Player explosion if the ship runs into the asteroid
        if (other.CompareTag ("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue); //Adds the score for shooting an asteroid
        Destroy(other.gameObject); //This is destroyed at the end of the frame
        Destroy(gameObject);
    }
}
