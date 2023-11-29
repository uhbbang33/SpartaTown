using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        SetTimeScale(0.0f);
    }

    public void SetTimeScale(float ts)
    {
        Time.timeScale = ts;
    }
}
