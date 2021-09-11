using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
        public AudioSource myFX;
        public AudioClip sound;

	public void Hover()
	{
		myFX.PlayOneShot(sound);
	}

	// Find audio if we lose it
	private void Update()
	{
		if (myFX.isActiveAndEnabled != true)
		{
			myFX = GameObject.Find("Main menu").GetComponent<AudioSource>();
		}
	}

	public void UpdateVolume(float value)
	{
		myFX.volume = value;
	}
}
