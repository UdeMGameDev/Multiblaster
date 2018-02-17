using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSequence : MonoBehaviour
{

    public ParticleSystem[] sequence;

    // Use this for initialization
    void Start()
    {
		StartCoroutine(playSequence());
    }

    IEnumerator playSequence()
    {
        for (int i = 0; i < sequence.Length; i++)
        {
			var main = sequence[i].main;
			main.loop = false;
            Instantiate(sequence[i], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(sequence[i].main.duration);
        }
    }
}
