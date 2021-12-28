using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterUI : MonoBehaviour
{
    public GameManager gameManager;
    
    public void PauseButton_Click()
    {
        if(gameManager.IsPaused)
            gameManager.UnPauseGame();
        else
            gameManager.PauseGame();
    }
}
