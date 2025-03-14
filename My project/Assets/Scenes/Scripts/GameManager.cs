using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;
    public int redKeys = 0;
    public int greenKeys = 0;
    public int blueKeys = 0;
    public int goldKeys = 0;


    public void AddPoints(int punkty_do_dodania)
    {
        points += punkty_do_dodania;
    }
    public void AddTime(int time_added)
    {
        timeToEnd += time_added;
    }
    public void FreezeTime(uint freeze_time)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze_time, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Red)
        {
            redKeys = redKeys+ 1;
            //redKeys++;
        }
    }

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
        Debug.Log("Time: " + timeToEnd + " s");
        InvokeRepeating("Stopper", 2, 1);
    }
    void Update()
    {
        PauseCheck();
    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
        {
            EndGame();
        }
    }
    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void EndGame()

    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reoad?");
        }
        else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }
    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}