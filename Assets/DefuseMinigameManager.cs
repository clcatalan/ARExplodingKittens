using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefuseMinigameManager : MonoBehaviour
{
    public static bool lineStarted;
    public static bool endPointConnected;

    public static bool gameOver;
    public static bool playerWon {get; private set;}

    private void Start() {
        lineStarted = false;
        endPointConnected = false;
        gameOver = false;
        playerWon = false;
    }

    public static void ChangeGameState() {
         if (lineStarted && endPointConnected) {
            gameOver = true;
            playerWon = true;
         }
    }

    public static void resetGameStatuses() {
        lineStarted = false;
        endPointConnected = false;
        gameOver = false;
        playerWon = false;
        
    }
}
