using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeY;

    private Vector2 startPosition;

	void Start () {
        startPosition = transform.position;
	}

	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector2.up * newPosition;
	}
}
