using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitPlacementManager : MonoBehaviour
{
    public static UnitPlacementManager instance;
    private bool game_paused = false;
    public GameObject pause_menu;
	public GameObject advanced_pause_menu;
	private AudioSource bgmusic;
	static public bool unit_is_selected = false;
	public TextMeshProUGUI get_lives;

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

	void setLives()
	{

	}


}
