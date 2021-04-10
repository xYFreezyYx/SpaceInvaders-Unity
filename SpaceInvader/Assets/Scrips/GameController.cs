using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject enemyContainer, hudContainer;
    public Text killCounter, timeCounter;
    public int numTotalEnemys, numTotalKills;
    private float startTime, elapsedTime;
    TimeSpan timePlaying;
    public bool gamePlaying;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        numTotalEnemys = enemyContainer.transform.childCount;
        numTotalKills = 0;
        killCounter.text = $"{numTotalKills} / {numTotalEnemys}";
        elapsedTime = 3;
        gamePlaying = false;
        BeginGame();
    }

    public void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }

    public void Kills()
    {
        numTotalKills++;

        string enemyCounterStr = $"{numTotalKills} / {numTotalEnemys}";
        killCounter.text = enemyCounterStr;
    }

    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = timePlaying.ToString("mm':'ss':'ff");
            timeCounter.text = timePlayingStr;

            if (numTotalKills == numTotalEnemys)
            {
                gamePlaying = false;
            }
        }
    }
}
