using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.breakout_new.Scripts
{
	public class GameManager : Singleton<GameManager>
	{
    	private int _brickCount, _lifeCount, _score; // used to store num of remaining bricks and ;ives
    	private bool _isGameOver;

    	[SerializeField] private Transform bricks; // will store a game object that contains all the bricks and set the brick count variable
    	[SerializeField] private Toggle[] lives; // will store the individual life objects and set life count variable
    	[SerializeField] private RectTransform loseScreen, winScreen; // will store the objects of the gui
    	[SerializeField] private TextMeshProUGUI score; // will store score object in the gui to update it with the current score
    	[SerializeField] private float time; // will store the delay in seconds that we will wait before Restarting 


    public void CollideBrick(Collision other)
    {
        if (_isGameOver) return;
        _brickCount++;
        other.gameObject.SetActive(false);
        score.text = $"Score: {++_score}";
        if (_brickCount >0) return;
        _isGameOver = true;
        winScreen.gameObject.SetActive(true);
        Invoke(nameof(Restart), time);
    }

    public void CollideWater()
    {
        if (_isGameOver) return;
        _lifeCount--;
        lives[_lifeCount] = false;
        score.text = $"Score: {--_score}";
        if (_lifeCount > 0) return;
        _isGameOver = true;
        loseScreen.gameObject.SetActive(true);
        Invoke(nameof(Restart), time);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Reset()
    {
        bricks = null;
        lives = null;
        loseScreen = null;
        score = null;
        winScreen = null;
        time = 5;
    }
    // Start is called before the first frame update
    private void Start()
    {
        _brickCount = 32;
        _isGameOver = false;
        _lifeCount = 5;
        Time.timeScale = 0;
        _score = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isGameOver) return;
        
        if (Input.GetKeyUp('R'))
        {
            Invoke(nameof(Restart), 0);
        } else if (Input.GetKeyUp(KeyCode.Escape))
        {
            //pause
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            // resume
            Time.timeScale = 1;
        }
        else
        {
            // nothing
        }

    }
}
}