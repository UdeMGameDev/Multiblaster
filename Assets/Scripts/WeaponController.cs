using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private AudioSource audiosource;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delayBeforeShooting;
    

	// Use this for initialization
	void Start ()
    {
        audiosource = shot.GetComponent<AudioSource>();
        InvokeRepeating("Fire", delayBeforeShooting, fireRate);
    }
	void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audiosource.Play();
    }

}
