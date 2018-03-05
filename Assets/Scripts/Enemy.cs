using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


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
}
