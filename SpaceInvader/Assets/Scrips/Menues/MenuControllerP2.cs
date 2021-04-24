using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControllerP2 : MonoBehaviour
{
    public static MenuControllerP2 instance;
    public Button play, controls, quit, p1, p2;

    private void Start()
    {
        MenuMusicController.instance.InMenu = true;
        play.onClick.AddListener(ButtonClickPlay);
        controls.onClick.AddListener(ButtonClickControlls);
        quit.onClick.AddListener(ButtonClickQuit);
        p1.onClick.AddListener(ButtonClickSinglePlayer);
        p2.onClick.AddListener(ButtonClickMultyPlayer);
        play.Select();
    }

    private void ButtonClickPlay()
    {
        SceneManager.LoadScene("P2-Level 1-Hp3");
    }

    private void ButtonClickControlls()
    {
        SceneManager.LoadScene("ControllsMenu");
    }

    private void ButtonClickQuit()
    {
        Application.Quit();
    }

    private void ButtonClickSinglePlayer()
    {
        SceneManager.LoadScene("P1MainMenu");
    }

    private void ButtonClickMultyPlayer()
    {
        
    }
}
