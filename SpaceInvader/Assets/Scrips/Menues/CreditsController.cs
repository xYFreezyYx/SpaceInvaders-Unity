using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public static CreditsController instance;
    public GameObject creditsOnOff, creditScene;
    public Button mainMenu, credits, quit, back;
    public string menuScene;
    public bool creditRoll;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameMusicController.instance.InGame = false;
        CreditMusicController.instance.InCredits = true;
        creditRoll = false;
        creditScene.SetActive(false);
        creditsOnOff.SetActive(true);
        mainMenu.onClick.AddListener(ButtonClickMenu);
        credits.onClick.AddListener(ButtonClickCredits);
        quit.onClick.AddListener(ButtonClickQuit);
        back.onClick.AddListener(ButtonClickBack);
        mainMenu.Select();
    }

    public void ButtonClickMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void ButtonClickCredits()
    {
        creditsOnOff.SetActive(false);
        creditScene.SetActive(true);
        creditRoll = true;
    }

    public void ButtonClickQuit()
    {
        Application.Quit();
    }
    public void ButtonClickBack()
    {
        creditsOnOff.SetActive(true);
        creditScene.SetActive(false);
        creditRoll = false;
    }    
}
