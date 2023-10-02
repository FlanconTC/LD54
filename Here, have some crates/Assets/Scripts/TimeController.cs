using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] public Button startButton;
    [SerializeField] public Button quitButton;
    [SerializeField] public Image _image;
    [SerializeField] public Text _gameOver;
    [SerializeField] public Text _rules;

    [SerializeField] public Text _ScoreTextMenu;
    [SerializeField] public Text _HighscoreTextMenu;
    [SerializeField] public Text _Score;
    [SerializeField] public Text _highscore;

    [SerializeField] public Text _ScoreTextInGame;
    [SerializeField] public Text _ScoreIntInGame;
    [SerializeField] public Text _TimeUntilInGame;
    [SerializeField] public Text _intUntilInGame;
    [SerializeField] public Text _textLives;
    [SerializeField] public Text _intLives;

    [SerializeField] public Text _logo;
    int highScore = 0;
 
    public void Start()
    {
        Time.timeScale = 0.0f;
        _gameOver.gameObject.SetActive(false);
        _rules.gameObject.SetActive(true);


        _ScoreTextInGame.gameObject.SetActive(false);
        _ScoreIntInGame.gameObject.SetActive(false);
        _TimeUntilInGame.gameObject.SetActive(false);
        _intUntilInGame.gameObject.SetActive(false);
        _textLives.gameObject.SetActive(false);
        _intLives.gameObject.SetActive(false);

      
    }

    public void Update()
    {
        if(_intLives.text == "0") 
        {
            GameOver(int.Parse(_ScoreIntInGame.text.ToString()));
        }
    }

    public void PlayGame() 
    {
        _image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        Time.timeScale = 1.0f;
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
       
        _rules.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
        _ScoreTextInGame.gameObject.SetActive(true);
        _ScoreIntInGame.gameObject.SetActive(true);
        _TimeUntilInGame.gameObject.SetActive(true);
        _intUntilInGame.gameObject.SetActive(true);
        _textLives.gameObject.SetActive(true);
        _intLives.gameObject.SetActive(true);
        _logo.gameObject.SetActive(false);

        _ScoreTextMenu.gameObject.SetActive(false);
        _HighscoreTextMenu.gameObject.SetActive(false);
        _Score.gameObject.SetActive(false);
        _highscore.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void GameOver(int score) 
    {
        _ScoreTextInGame.gameObject.SetActive(false);
        _ScoreIntInGame.gameObject.SetActive(false);
        _TimeUntilInGame.gameObject.SetActive(false);
        _intUntilInGame.gameObject.SetActive(false);
        _textLives.gameObject.SetActive(false);
        _intLives.gameObject.SetActive(false);
        _image.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        Time.timeScale = 0.0f;
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        _logo.gameObject.SetActive(true);
        _gameOver.gameObject.SetActive(true);
      if(score > highScore) 
        { 
            highScore = score;
        }
        _highscore.text = highScore.ToString();
        _Score.text = score.ToString();

        _ScoreTextMenu.gameObject.SetActive(true);
        _HighscoreTextMenu.gameObject.SetActive(true);
        _Score.gameObject.SetActive(true);
        _highscore.gameObject.SetActive(true);
    }
}
