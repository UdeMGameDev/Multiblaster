using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFiller : MonoBehaviour {

	Image image;
	public FloatReference variable;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
		image.fillAmount = variable.variable.value / variable.variable.maxValue;
	}
}
