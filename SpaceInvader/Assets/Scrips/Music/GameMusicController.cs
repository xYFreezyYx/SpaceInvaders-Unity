using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicController : MonoBehaviour
{
    private static GameMusicController _instance;
    public static GameMusicController instance;
    public bool InGame;

    private void Awake()
    {
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
        if (InGame == false)
        {
            Destroy(gameObject);
            return;
        }
    }
}
