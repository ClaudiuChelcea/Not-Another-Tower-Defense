using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScripts : MonoBehaviour
{
	// Button hover
	public AudioSource source;
	public AudioClip clip;

	// For the non-implemented levels
	public void GoBack()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}

	// Button hover sound
	public void MouseHover()
	{
		source.PlayOneShot(clip);
	}
}
