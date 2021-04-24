using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{
    private static MenuMusicController _instance;
    public static MenuMusicController instance;
    public bool InMenu;

    private void Awake()
    {
        InMenu = true;
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        instance = _instance;

        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (InMenu == false)
        {
            Destroy(gameObject);
            return;
        }
    }
}