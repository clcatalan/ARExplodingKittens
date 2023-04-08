using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueFalseManager : MonoBehaviour
{
    public static bool questionAsked;
    public static bool questionAnswered;

    private void Start() {
        questionAsked = false;
        questionAnswered = false;
    }

    public static void ChangeGameState() {
        if (questionAsked && questionAnswered) {
            EndGame();
        }
    }

    public static void resetGameStatuses() {
        questionAsked = false;
        questionAnswered = false;
        
    }

    public static void EndGame() {
        resetGameStatuses();
        SceneManager.LoadScene("CardTrackerScene");
    }
}