using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefuseUIManager : MonoBehaviour
{

    [SerializeField] private TextMeshPro gameStatusText;
    [SerializeField] private TextMeshPro countdownText;

    public static string statusText = "Looking for card...";
    // Start is called before the first frame update
    private void Update() {
        // if (DefuseMinigameManager.gameOver && DefuseMinigameManager.playerWon) {
        //     statusText = "KITTEN DEFUSED!";
        // } else if (DefuseMinigameManager.gameOver && !DefuseMinigameManager.playerWon) {
        //     statusText = "KITTEN EXPLODED!";
        // }

        gameStatusText.text = statusText;

        countdownText.text = $"{Mathf.RoundToInt(CountdownManager.timeRemaining)}";
    }
}
