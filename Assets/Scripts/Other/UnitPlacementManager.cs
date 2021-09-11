using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
	public GameObject loseMenu, winMenu, mainCanvas;
	private string fileName = "Assets/User/Balance.txt";
	public static int global_enemies_deaths_count = 0;
	public int lives_to_have_to_lose = 0, enemies_to_kill_to_win = 20;

	public void SetUnitSelectedTrue()
	{
		UnitPlacementManager.unit_is_selected = true;
	}

	private void Reset()
	{
		game_paused = false;
		current_units = 0;
		next_units = 0;
		current_enemies = 0;
		next_enemies = 0;
		global_enemies_deaths_count = 0;
		get_lives.text = GameBalance.lives.ToString();
		game_paused = false;
		break_update = false;
		mainCanvas.SetActive(true);
		winMenu.SetActive(false);
		loseMenu.SetActive(false);
		Time.timeScale = 1;
		break_update = false;
	}

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one UnitPlacementManager in scene!");
		}

		instance = this;

		Reset();
	}

	public GameObject archerPrefab;
	public GameObject knightPrefab;
	private bool break_update = false;

	private void Start()
	{
		unitToPlace = archerPrefab;
		bgmusic = GetComponent<AudioSource>();
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
		if (break_update == true)
			return;
		Lose();
		Win();

	}

	private void Lose()
	{
		if (PathFollower.receive_lives == lives_to_have_to_lose)
		{
			loseMenu.SetActive(true);
			Time.timeScale = 0;
			mainCanvas.SetActive(false);
			game_paused = true;
			break_update = true;
		}
	}

	private void Win()
	{
		if (global_enemies_deaths_count == enemies_to_kill_to_win)
		{
			winMenu.SetActive(true);
			Time.timeScale = 0;
			mainCanvas.SetActive(false);
			GameBalance.starter_balance += 5;
			game_paused = true;

			File.Delete(fileName);
			File.WriteAllText(fileName, GameBalance.starter_balance.ToString());
			break_update = true;
		}
	}

	private void EnemiesSounds()
	{
		// Get enemies
		next_enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
		if (next_enemies < current_enemies)
		{
			death.PlayOneShot(explodesound);
			UnitPlacementManager.global_enemies_deaths_count++;
		}

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
