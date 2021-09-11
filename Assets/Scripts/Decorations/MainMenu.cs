using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void Play_Level_1()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1");
		Debug.Log("Loading 1st scene");
	}

	public void Play_Level_2()
	{
		SceneManager.LoadScene("Level_2");
	}

	public void Play_Level_3()
	{
		SceneManager.LoadScene("Level_3");
	}

	public void Play_Level_4()
	{
		SceneManager.LoadScene("Level_4");
	}

	public void Play_Level_5()
	{
		SceneManager.LoadScene("Level_5");
	}

	public void Play_Level_6()
	{
		SceneManager.LoadScene("Level_6");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
