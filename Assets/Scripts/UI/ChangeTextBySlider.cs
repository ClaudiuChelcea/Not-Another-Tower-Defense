using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextBySlider : MonoBehaviour
{
	public TMPro.TextMeshProUGUI mytext;

	private void Start()
	{
		 mytext = GetComponent<TMPro.TextMeshProUGUI>();
	}


	public void ChangeText(float value)
	{
		mytext.text = System.Convert.ToInt32(value * 100).ToString() + "%";
	}
}
