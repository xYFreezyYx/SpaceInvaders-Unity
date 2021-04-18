using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuConController : MonoBehaviour
{
    public GameObject KeysPanel, ControllerPanel, ControlsUI;
    public Button back, KeysBack, KeysControls, ControllerBack, ControllerControls;
    public bool keyBordAndMouse, controller;

    private void Start()
    {
        keyBordAndMouse = false;
        controller = false;
        ControlsUI.SetActive(true);
        KeysPanel.SetActive(false);
        ControllerPanel.SetActive(false);
        back.onClick.AddListener(ButtonClickBack);
        KeysBack.onClick.AddListener(ChooseControlles);
        ControllerBack.onClick.AddListener(ChooseControlles);
        KeysControls.onClick.AddListener(ButtonClickKeyBordAndMouseControls);
        ControllerControls.onClick.AddListener(ButtonClickControllerControls);
        back.Select();
    }

    private void ButtonClickBack()
    {
        SceneManager.LoadScene("P1MainMenu");
    }

    private void ButtonClickKeyBordAndMouseControls()
    {
        keyBordAndMouse = true;
        controller = false;
        KeysPanel.SetActive(true);
        ControllerPanel.SetActive(false);
        ControlsUI.SetActive(false);
        KeysBack.Select();
    }

    private void ButtonClickControllerControls()
    {
        keyBordAndMouse = false;
        controller = true;
        KeysPanel.SetActive(false);
        ControllerPanel.SetActive(true);
        ControlsUI.SetActive(false);
        ControllerBack.Select();
    }

    private void ChooseControlles()
    {
        if (keyBordAndMouse == true)
        {
            keyBordAndMouse = false;
            controller = false;
            KeysPanel.SetActive(false);
            ControllerPanel.SetActive(false);
            ControlsUI.SetActive(true);
            back.Select();
        }

        if (controller == true)
        {
            keyBordAndMouse = false;
            controller = false;
            KeysPanel.SetActive(false);
            ControllerPanel.SetActive(false);
            ControlsUI.SetActive(true);
            back.Select();
        }
    }
}
