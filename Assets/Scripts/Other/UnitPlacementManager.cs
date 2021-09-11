using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UnitPlacementManager : MonoBehaviour
{
	public static UnitPlacementManager instance;
	private bool game_paused = false;
	public GameObject pause_menu;
	public GameObject advanced_pause_menu;
	private AudioSource bgmusic;
	static public bool unit_is_selected = false;
	public TextMeshProUGUI get_lives;
	public AudioSource death;
	public AudioClip deathsound;
	public AudioClip roger_that;
	private int current_units  = 0;
	private int next_units = 0;
	public AudioClip explodesound;
	private int current_enemies = 0;
	private int next_enemies = 0;

	public void SetUnitSelectedTrue()
	{
		UnitPlacementManager.unit_is_selected = true;
	}

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one UnitPlacementManager in scene!");
		}

		instance = this;
	}

	public GameObject archerPrefab;
	public GameObject knightPrefab;

	private void Start()
	{
		unitToPlace = archerPrefab;
		bgmusic = GetComponent<AudioSource>();
		get_lives.text = GameBalance.lives.ToString();
	}

	private GameObject unitToPlace;

	public GameObject GetUnitToPlace()
	{
		return unitToPlace;
	}

	private void Update()
	{
		// On 'ESC' hold
		PauseGame();
		ResumeGame();
		if (game_paused == true)
			bgmusic.Pause();
		else if (game_paused == false)
			bgmusic.UnPause();

		ArcherSounds();
		EnemiesSounds();
	}

	private void EnemiesSounds()
	{
		// Get enemies
		next_enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
		if (next_enemies < current_enemies)
			death.PlayOneShot(explodesound);
		current_enemies = next_enemies;
	}

	private void ArcherSounds()
	{
		// Get archers
		next_units = GameObject.FindGameObjectsWithTag("Unit").Length;
		if (next_units < current_units)
			death.PlayOneShot(deathsound);
		else if (next_units > current_units)
			death.PlayOneShot(roger_that);
		current_units = next_units;
	}

	private void PauseGame()
	{
		if (game_paused == false && Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 0;
			game_paused = true;
			pause_menu.active = true;
		}
	}

	public void ResumeGame()
	{
		if (game_paused == true && Input.GetKeyUp(KeyCode.Escape))
		{
			Time.timeScale = 1;
			pause_menu.active = false;
			game_paused = false;
			advanced_pause_menu.active = false;
		}
	}

	public void ForceResume()
	{
		Time.timeScale = 1;
		pause_menu.active = false;
		game_paused = false;
		advanced_pause_menu.active = false;
	}

	public void GoBack()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}

	// BG Music Volume
	public void setVolume(float value)
	{
		bgmusic.volume = value;
	}
}
