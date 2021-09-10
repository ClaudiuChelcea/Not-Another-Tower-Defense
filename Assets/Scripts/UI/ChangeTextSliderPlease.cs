using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextSliderPlease : MonoBehaviour
{
	TMPro.TextMeshProUGUI my_text;

	private void Start()
	{
		my_text = GetComponent<TMPro.TextMeshProUGUI>();
	}

	public void UpdateMe(float value)
	{
		my_text.text = Mathf.Round(value * 100).ToString() + "%";
	}
}
