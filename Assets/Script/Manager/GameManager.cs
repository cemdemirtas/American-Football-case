using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject StartP, InGameP, NextP, GameOverP;
    public float countdown = 2.0f; 
    [SerializeField] private int asynSceneIndex = 1;
    public enum GameState // we arrange state and panels
    {
        Start,
        InGame,
        Next,
        GameOver
    }
    public GameState gamestate; //get reference
    public enum Panels
    {
        Startp,
        Nextp,
        GameOverp,
        InGamep
    }

    private void Start()
    {
        gamestate = GameState.Start;
    }
    public void Update()
    {
        switch (gamestate)
        {
            case GameState.Start:
                GameStart();
                break;
            case GameState.InGame:
                InGame();
                break;
            case GameState.Next:
                Next();
                break;
            case GameState.GameOver:
                GameOver();
                break;

        }
    }
    public void PanelController(Panels currentpanel)
    {
        StartP.SetActive(false);
        InGameP.SetActive(false);
        NextP.SetActive(false);
        GameOverP.SetActive(false);
        switch (currentpanel)
        {
            case Panels.Startp:
                StartP.SetActive(true);
                break;
            case Panels.Nextp:
                NextP.SetActive(true);
                break;
            case Panels.GameOverp:
                GameOverP.SetActive(true);
                break;
            case Panels.InGamep:
                InGameP.SetActive(true);

                break;
        }

    }
    void GameStart()
    {
        PanelController(Panels.Startp);
        if (Input.anyKeyDown)
            gamestate = GameState.InGame;
        if (SceneManager.sceneCount < 2)
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);




    }
    void InGame()
    {
        PanelController(Panels.InGamep);

    }
    void Next()
    {
        PanelController(Panels.Nextp);

    }
    void GameOver()
    {
        countdown -= Time.deltaTime;
        if (countdown < 0)
        { 
            PanelController(Panels.GameOverp);
            countdown = 2.5f;

        }

    }
    public void RestartButton()
    {

        SceneManager.UnloadSceneAsync(asynSceneIndex);
        //SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        gamestate = GameState.Start;
    }

    public void NextLevelButton() //When the game finished, we get loop each levels to infinity
    {
        if (SceneManager.sceneCountInBuildSettings == asynSceneIndex + 1)
        {
            SceneManager.UnloadSceneAsync(asynSceneIndex);
            asynSceneIndex = 1;
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        }
        else
        {
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(asynSceneIndex);
                asynSceneIndex++;
            }
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        }
        gamestate = GameState.Start;
    }
}
