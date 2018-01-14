using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

//Commentaire!!!

public class PlayerController : MonoBehaviour
{
    private GameController gameController; //GameController == Class, gameController == one instance of the class

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public Boundary boundary;

    public GameObject shot;
    private Transform shotSpawn;

    public float fireRate; //Time between each fires
    private float nextFire; //Time until next shot is available

    public float speed; //Speed of the shots

    void Start()

    {   //Finds the Game Controller object, if any, for each instantiation of the enemy
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

		shotSpawn = transform.Find ("ShotSpawn");
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; //Update the timers for shots
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate ()
    {
            float moveH = Input.GetAxis("Horizontal");
            float moveV = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveH, moveV) * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);

            rb.transform.position = new Vector2(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
    }
}
