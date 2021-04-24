using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMusicController : MonoBehaviour
{
    private static CreditMusicController _instance;
    public static CreditMusicController instance;
    public bool InCredits;

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
        if (InCredits == false)
        {
            Destroy(gameObject);
            return;
        }
    }
}
