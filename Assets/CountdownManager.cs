using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    private float startTime = 20f;
    public static float timeRemaining {get; private set;}

    private void Start() {
        timeRemaining = startTime;
    }

    private void Update() {

        if (!DefuseMinigameManager.gameOver)
            timeRemaining -= Time.deltaTime;
            
        if (timeRemaining < 0) {
            timeRemaining = 0;
        }

        // Debug.Log(timeRemaining);
     }

}
