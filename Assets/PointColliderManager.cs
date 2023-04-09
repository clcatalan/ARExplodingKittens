using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointColliderManager : MonoBehaviour
{
    [SerializeField] private GameObject pathwayBorder;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;

    private void Update() {
        if (DynamicBeam.intersectedObject == endPoint && DefuseMinigameManager.lineStarted == true) {
            DefuseMinigameManager.endPointConnected = true;
            DefuseMinigameManager.instance.ChangeGameState();
        }
        if (CountdownManager.timeRemaining <= 0 && DefuseMinigameManager.endPointConnected == false) {
            DefuseMinigameManager.instance.ChangeGameState();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (DynamicBeam.CheckTrigger() == true) {
            DefuseMinigameManager.lineStarted = true;
            DynamicBeam.beamLine.startColor = Color.blue;
        } else {
            DynamicBeam.beamLine.startColor = Color.grey;
        }
    }

    private void OnMouseExit() {
        if (!DefuseMinigameManager.gameOver) {
            if (DynamicBeam.CheckTrigger() && gameObject == startPoint) {
                Debug.Log("MOUSE LEFT BOX");
            }

            if (DynamicBeam.CheckTrigger() && gameObject == pathwayBorder) {
                DrawLine.DestroyExistingLine();
                DefuseMinigameManager.resetGameStatuses();
            }
        }
    }

    private void OnMouseDown() {
        if (!DefuseMinigameManager.gameOver) {
            if (gameObject == startPoint) {
                DefuseMinigameManager.lineStarted = true;
                Debug.Log("LINE STARTED");
            }
        }
    }

    private void OnMouseEnter() {
        if (!DefuseMinigameManager.gameOver) {
            if (Input.GetMouseButton(0) && gameObject == endPoint) {
                DefuseMinigameManager.endPointConnected = true;
                DefuseMinigameManager.instance.ChangeGameState();
            }
        }
    }

    private void OnMouseOver() {
        
    }
}
