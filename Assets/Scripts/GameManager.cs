using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    #region Declaring Variables
    public static int Score;
    private int _maxScore;
    public static int Lives = 3;

    public GameObject GameOverPanel;
    public GameObject YouWinPanel;


    private bool _gameOver;
    public static bool GameWon;
 
    public Text ScoreText;
    public Text LivesText;
    private int currentLvl;

    private GameObject _ballREF;
    #endregion


    [Header("Brick Spawn Info")]
    public GameObject BrickPrefab;
    public int Value;

    [Header("Brick Color Settings")]
    public Color[] _colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };

    void Start ()
    {

        currentLvl = SceneManager.GetActiveScene().buildIndex;
        _ballREF = GameObject.FindGameObjectWithTag("Ball");
        SpawnBricks();

        // Increases balls "speed" each lvl.
        switch (currentLvl)
        {
            case 1:
                _ballREF.GetComponent<Ball>().speed = new Vector2(6, -6);
                _maxScore =  55;
                break;

            case 2:
                _ballREF.GetComponent<Ball>().speed = new Vector2(8, -8);
                _maxScore =  110;
                break;
        }

	}
	

	void Update ()
    {

        ScoreText.text = Score.ToString();
        LivesText.text = Lives.ToString();

        if(Lives <= 0)
        {
            _gameOver = true;
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if(_gameOver == true && Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            Lives = 3;
            Score = 0;
            GameOverPanel.SetActive(false);
            SceneManager.LoadScene(1);
           
        }

        if (Score == _maxScore && Lives >= 1)
        {
            YouWinPanel.SetActive(true);
            Time.timeScale = 0.3f;
            StartCoroutine(WinDelay());
        }
    }

    // Inner & Outer for loops used to create bricks in scence
    void SpawnBricks()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int x = 0; x < 5; x++)
            {
                GameObject _brick = Instantiate(BrickPrefab);
                _brick.transform.position = new Vector2(x * 3, 4 - i) + new Vector2(-6, 0);
                SpriteRenderer _renderer = _brick.GetComponent<SpriteRenderer>();
                _renderer.material.color = _colors[i];

            }
        }
    }

    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(0.5f);
        YouWinPanel.SetActive(false);
        Time.timeScale = 1f;

        if (SceneManager.GetActiveScene().buildIndex < 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            GameWon = true;
            SceneManager.LoadScene(0);
        }
    }
}
