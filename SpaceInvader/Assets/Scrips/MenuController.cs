using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button play, tutorial, quit, p1, p2;

    private void Start()
    {
        play.onClick.AddListener(ButtonClickPlay);
        tutorial.onClick.AddListener(ButtonClickControlls);
        quit.onClick.AddListener(ButtonClickQuit);
        p1.onClick.AddListener(ButtonClickSinglePlayer);
        p2.onClick.AddListener(ButtonClickMultyPlayer);
        play.Select();
    }

    private void ButtonClickPlay()
    {
        SceneManager.LoadScene("Level 1-Hp3");
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

    }

    private void ButtonClickMultyPlayer()
    {

    }
}
