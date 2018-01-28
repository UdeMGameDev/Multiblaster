using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioSequence : MonoBehaviour
{

    private AudioSource source;
    public AudioClip[] clips;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
		source.loop = false; //clips are played one after the other
        StartCoroutine(playSequence());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playSequence()
    {
        for (int i = 0; i < clips.Length; i++)
        {
            source.clip = clips[i];
            source.Play();
			if (i == clips.Length-1) source.loop = true; //last clip will be looped
            yield return new WaitForSeconds(source.clip.length);
        }
    }
}
