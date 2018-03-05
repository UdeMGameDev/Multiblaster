using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public int value; //how much it affects the (good or bad) hp bar
    public FloatReference affectedValue;


	void OnTriggerEnter2D(Collider2D other)
	{
		string tag = this.tag;
        string otherTag = other.tag;

		if (other.tag == "Player")
		{
			Destroy(this.gameObject);
			affectedValue.variable.Value += value;
		}
	}
}
