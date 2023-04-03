using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.MagicLeap;

public class DrawLine : MonoBehaviour
 {
     Coroutine drawing;
     [SerializeField] GameObject canvas;
     [SerializeField] GameObject rectangle;

     private GameObject startCheckPoint;
     private GameObject endCheckPoint;
     public static bool isDrawing {get; private set;}
    private void Awake() {
        isDrawing = false;

        startCheckPoint = GameObject.Find("Canvas/EndPoints/Start Checkpoint");
        endCheckPoint = GameObject.Find("Canvas/EndPoints/End Checkpoint");
    }
     
     public void Update()
     {
        if (DynamicBeam.CheckTrigger() == true && 
            DynamicBeam.intersectedObject == startCheckPoint) {

            DynamicBeam.UpdateLineColor(Color.red);

            if (isDrawing == false) {
                StartLine();
                DefuseMinigameManager.lineStarted = true;
                isDrawing = true;
            }
        }

        if (DynamicBeam.CheckTrigger() == false) {
            if (isDrawing == true) {
                FinishLine();
                isDrawing = false;
            }
        }

     }

     void StartLine() {
        if (drawing != null) {
            StopCoroutine(drawing);
        }

        // if (DefuseMinigameManager.lineStarted && !DefuseMinigameManager.gameOver) {
        drawing = StartCoroutine(MakeLine());
        // }
     }

     void FinishLine() {
        if (drawing != null)
            StopCoroutine(drawing);

        // if (!DefuseMinigameManager.endPointConnected) {
        //     DestroyExistingLine();
        //     DefuseMinigameManager.resetGameStatuses();
        // }
     }

     public static void DestroyExistingLine() {
        GameObject line = GameObject.Find("Canvas/Line(Clone)");
        if (line != null) {
            Object.Destroy(line);
        }
     }

    IEnumerator MakeLine() {
        GameObject existingLine = GameObject.Find("Canvas/Line(Clone)");
        if (existingLine != null) {
            Object.Destroy(existingLine);
        }

        GameObject newGameObject = Instantiate(Resources.Load("Line") as GameObject, new Vector3(0,0,0),
                                 Quaternion.identity, canvas.transform);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        // MeshCollider collider = newGameObject.AddComponent<MeshCollider>();
        line.positionCount = 0;

        while (true) {
            Vector3 controllerPos = DynamicBeam.beamLine.GetPosition(1);
            // controllerPos.z = canvas.transform.position.z - 1;
            controllerPos.z = rectangle.transform.position.z;
            // Vector3 mousepos = Input.mousePosition;
            // mousepos.z = canvas.transform.position.z;
            // Vector3 position = Camera.main.ScreenToWorldPoint(controllerPos);
            // DefuseUIManager.statusText = controllerPos.ToString();
            try {
                line.positionCount++;
            } catch (MissingReferenceException) {
                break;
            }
            line.SetPosition(line.positionCount - 1, controllerPos);
            string textS = $"{line.GetPosition(line.positionCount - 1).ToString()} {line.GetPosition(0).ToString()}";
            // GenerateMeshCollider(newGameObject, line, collider);
            yield return null;
        }
    }
     
 }