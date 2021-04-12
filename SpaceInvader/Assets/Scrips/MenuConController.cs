using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuConController : MonoBehaviour
{
    public Button back;

    private void Start()
    {
        back.onClick.AddListener(ButtonClickBack);
        back.Select();
    }

    private void ButtonClickBack()
    {
        SceneManager.LoadScene("P1MainMenu");
    }
}
