using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeepHighlighted : MonoBehaviour
{
	public Button ButtonGameObject;

	private void Start()
	{
		ButtonGameObject = GetComponent<Button>();
	}

	// Update is called once per frame

	private void Update()
	{
		// Atat timp cat butonul e selectat
		if(EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.name == ButtonGameObject.name)
		{
			UnitPlacementManager.unit_is_selected = true;
		}
		else
		{
			UnitPlacementManager.unit_is_selected = false;
		}
	}

	public void SetMeActive()
	{
		EventSystem.current.SetSelectedGameObject(ButtonGameObject.gameObject); ;
	}
}
