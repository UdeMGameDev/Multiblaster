using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject {

	public float value;
	public float maxValue;


	public float Value {
		get { return this.value;}
		set
		{
			if (value < 0)
            	this.value = 0;
			else if (value > maxValue)
				this.value = maxValue;
			else
				this.value = value;
		}
	}


	
}
