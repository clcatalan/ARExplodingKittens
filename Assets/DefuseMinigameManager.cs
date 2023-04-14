using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Runtime.Versioning;

public class DefuseMinigameManager : MonoBehaviour
{
    public static bool lineStarted;
    public static bool endPointConnected;

    public static bool gameOver;
    public static bool playerWon {get; private set;}

    public static DefuseMinigameManager instance;

    [SerializeField] private AudioSource successSound;
    [SerializeField] private AudioSource explosionSound;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        lineStarted = false;
        endPointConnected = false;
        gameOver = false;
        playerWon = false;
    }

    public void ChangeGameState() {
         if (lineStarted && endPointConnected) {
            gameOver = true;
            playerWon = true;
         }

         if (CountdownManager.timeRemaining <= 0 && !endPointConnected) {
            gameOver = true;
            playerWon = false;
         }

        instance.StartCoroutine("ChangeGameStateCoroutine");

    }

    IEnumerator ChangeGameStateCoroutine() {
        if (gameOver && playerWon) {
            successSound.Play();
        } else if (gameOver && !playerWon) {
            DefuseUIManager.statusText = "Kitten exploded! Better luck next time...";
            explosionSound.Play();
        }
        yield return new WaitForSeconds(3);
        resetGameStatuses();
        SceneManager.LoadScene("CardTrackerScene");
    }

    public static void resetGameStatuses() {
        lineStarted = false;
        endPointConnected = false;
        gameOver = false;
        playerWon = false;
        
    }
}
