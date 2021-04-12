using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject enemyContainer, hudContainer, removeHp, gameOver, victory, gameUI, Hp1;
    public Button GOmainMenu, GOplayAgain, VplayAgain, VmainMenu, nextLevel;
    public Text killCounter, timeCounter, hpCounter;
    public int numTotalEnemys, numTotalKills, numTotalHp;
    private float startTime, elapsedTime;
    TimeSpan timePlaying;
    public bool gamePlaying;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GOmainMenu.onClick.AddListener(ButtonClickMainMenu);
        GOplayAgain.onClick.AddListener(ButtonClickPalyAgain);
        VmainMenu.onClick.AddListener(ButtonClickMainMenu);
        VplayAgain.onClick.AddListener(ButtonClickPalyAgain);
        nextLevel.onClick.AddListener(ButtonClickNextLevel);
        numTotalEnemys = enemyContainer.transform.childCount;
        numTotalKills = 0;
        killCounter.text = $"{numTotalKills} / {numTotalEnemys}";
        hpCounter.text = $"{numTotalHp}";
        elapsedTime = 3;
        victory.SetActive(false);
        gameOver.SetActive(false);     
        BeginGame();
    }

    public void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }

    private void ButtonClickMainMenu()
    {
        SceneManager.LoadScene("P1MainMenu");
    }

    private void ButtonClickPalyAgain()
    {
        SceneManager.LoadScene("Level 1-Hp3");
    }

    private void ButtonClickNextLevel()
    {

    }

    public void Kills()
    {
        numTotalKills++;

        string enemyCounterStr = $"{numTotalKills} / {numTotalEnemys}";
        killCounter.text = enemyCounterStr;
    }

    public void Hp()
    {
        numTotalHp--;

        string HpCounterStr = $"{numTotalHp}";
        hpCounter.text = HpCounterStr;

        numTotalEnemys--;

        string enemyCounterStr = $"{numTotalKills} / {numTotalEnemys}";
        killCounter.text = enemyCounterStr;

        if (numTotalHp == 2)
        {
            StartCoroutine(RewindHp2());
        }
        else if (numTotalHp == 1)
        {
            StartCoroutine(RewindHp1());
        }
    }

    IEnumerator RewindHp2()
    {
        Hp1.GetComponent<AudioSource>().Play();
        
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level 1-Hp2");
    }

    IEnumerator RewindHp1()
    {
        Hp1.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level 1-Hp1");
    }

    public void GameOver()
    {
        numTotalEnemys--;

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

            if (numTotalKills == numTotalEnemys || numTotalHp == 0)
            {
                removeHp.SetActive(false);
                gamePlaying = false;               
            }            
        }
        else if (gamePlaying == false)
        {
            StartCoroutine(WaitForSec());
        }        
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1.01f);

        if (numTotalKills == numTotalEnemys && numTotalHp != 0)
        {
            victory.SetActive(true);
            gameUI.SetActive(false);
        }
        else if (numTotalHp == 0)
        {
            gameOver.SetActive(true);
            gameUI.SetActive(false);
        }
    }
}
