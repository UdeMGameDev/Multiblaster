using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject {

	public float value;


	public float Value {
		get { return this.value;}
		set
		{
			if (value < 0)
            	this.value = 0;
        
			else
				this.value = value;
		}
	}

	public float maxValue;
	
}
