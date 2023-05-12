using System;
using UnityEngine;
using UnityEngine.Events;

public class GameStateController : MonoBehaviour
{
    public UnityEvent OnPlayerWon;
    public UnityEvent OnPlayerLose;
    public bool IsGameEnded = false;

    public static GameStateController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
