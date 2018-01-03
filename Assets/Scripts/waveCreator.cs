using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class waveCreator : MonoBehaviour {

    //public GameObject[] waves;
    //public Vector3[] array;// = new Vector3[5];

    [System.Serializable]
    public struct WaveSpawn
    {
        public string hazard;
        public string xPosition;
        public float waitNext; //in seconds

        public WaveSpawn(string Hazard, string XPosition, float WaitNext)
        {
            hazard = Hazard;
            xPosition = XPosition;
            waitNext = WaitNext;
        }
    }

    public WaveSpawn[] waves;

    public TextAsset waveFile; //Path to the corresponding text file (which contains the wave design)
    private string wholeText;
    private List<string> waveLines;

    private List<string> separate;

    /*The wave text files are arranged as follows:
     Each section corresponds to a line of enemy generation.
     Each line contains an enemy type (tag), an x position and the time to wait until the next enemy generation.
     If the time is zero, there are multiple enemies on the same line.*/

    // Use this for initialization
    void Start()
    { 
        /*wholeText = waveFile.text;
        

        waveLines = new List<string>();
        waveLines.AddRange(wholeText.Split("\n"[0]));

        for (int i = 0; i < waveLines.Count; i++)
        {
            waveLines.AddRange(waveLines[i].Split(" "[0]));
            Debug.Log(waveLines[i]);
            //separate = waveLines[i].Split(;
            waves[i] = new WaveSpawn(waveLines[i], waveLines[i], 13); // waveLines[i]);
        }
        */
    }
    // Update is called once per frame
    void Update () {
		
	}
}
