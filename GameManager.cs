using System;
using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public AbstractFSMClient[] FsmClients;
    public __MiniRoadControls miniRoadControls;

    [SerializeField]
    private bool isPaused = false;
    public bool isGameOver = false;
    [ReadOnlyField]
    public PlayerData playerData;
    public event EventHandler GamePaused = (o, args) => { };
    public event EventHandler GameUnPaused = (o, args) => { };

    private void Awake()
    {
        playerData = FindObjectOfType<SaveSystem>().PlayerData;
    }


    [Header("Для тестового режима")]
    public bool isTestMode;

    public bool IsPaused
    {
        get { return isPaused; }
    }

    public void Start()
    {
        FsmClients = FindObjectsOfType<AbstractFSMClient>();
    }

    public void PauseGame()
    {
        if (isTestMode) return;

        if (FsmClients.Length == 0) Start();

        foreach (var client in FsmClients)
        {
            client.DisableActions();
        }
        isPaused = true;
        miniRoadControls.isPaused = true;
        GamePaused(this, EventArgs.Empty);
    }
    
    public void UnPauseGame()
    {
        if (isGameOver) return;


        foreach (var client in FsmClients)
        {
            client.EnableActions();
        }
        isPaused = false;
        miniRoadControls.isPaused = false;
        GameUnPaused(this, EventArgs.Empty);

    }

    public void OnMoodFallToZero(object sender, EventArgs args)
    {
        if (isTestMode) return;
        FindObjectOfType<__EndGameControls>().Lose();
        isGameOver = true;
        PauseGame();
    }

    //TODO: Олег переделай эту дичь
    public void Win()
    {
        if (isTestMode) return;

        if (isGameOver) return;
        FindObjectOfType<__EndGameControls>().Win();
        PauseGame();

    }
}
