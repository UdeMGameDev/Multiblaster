using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController; //GameController == Class, gameController == one instance of the class

    public int HPValue; //how much it affects the (good or bad) hp bar
    public FloatReference affectedHP;

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

        string tag = this.tag;
        string otherTag = other.tag;

        if (tag == "PlayerShot")
        {
            return;
        }

        else if (tag == "EnemyShot")
        {
            if (otherTag == "Player")
            {
                Debug.Log("Player Destroyed");
            }
        }

        else if (tag == "Enemy" || tag == "GoodCell")
        {
  
            if (other.tag == "Player")
            {
                affectedHP.variable.Value += HPValue;
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);

                if (affectedHP.variable.Value <= 0)
                {
                    Destroy(other.gameObject); //This is destroyed at the end of the frame
                    
                    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                    gameController.GameOver();
                }
                
            }
            else if (otherTag == "PlayerShot")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);

                Instantiate(explosion, transform.position, transform.rotation);
            }
            
        }
          
        /*
        if (other.tag == "Boundary" || other.tag == "Enemy") //To avoid collision between enemies
        {
            return;
        }
        
        //ce bout de code est dégueu, à changer (c'est moi qui l'a écrit) ;) - Rémy
        if ((this.tag == "PlayerShot" || CompareTag("EnemyShot")) && other.CompareTag("PlayerShot") ){
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

        //Player explosion if the ship runs into an enemy
        if (other.CompareTag ("Player"))
        {
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
        }
        */

       
    }
}
