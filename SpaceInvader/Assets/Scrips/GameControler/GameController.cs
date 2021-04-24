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
    public string mainMenu, playAgain, rewindHp2, rewindHp1, NextLevel;
    TimeSpan timePlaying;
    public bool gamePlaying, bossLevel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MenuMusicController.instance.InMenu = false;
        GameMusicController.instance.InGame = true;
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
        bossLevel = false;
        BeginGame();
    }

    public void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }

    private void ButtonClickMainMenu()
    {
        if (bossLevel == false)
        {
            SceneManager.LoadScene(mainMenu);
            GameMusicController.instance.InGame = false;
        }        
    }

    private void ButtonClickPalyAgain()
    {
        SceneManager.LoadScene(playAgain);
    }

    private void ButtonClickNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
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
        removeHp.SetActive(false);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(rewindHp2);
    }

    IEnumerator RewindHp1()
    {
        Hp1.GetComponent<AudioSource>().Play();
        removeHp.SetActive(false);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(rewindHp1);
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

            if (numTotalHp == 0 || numTotalKills == numTotalEnemys)
            {
                if (Input.GetButtonDown("PlayAgain"))
                {
                    SceneManager.LoadScene(playAgain);
                }
            }

            if (Input.GetButtonDown("NextLevel"))
            {
                SceneManager.LoadScene(NextLevel);
            }

            if (bossLevel == false)
            {
                if (Input.GetButtonDown("MainMenu"))
                {
                    SceneManager.LoadScene(mainMenu);
                    GameMusicController.instance.InGame = false;
                }
            }            
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
