using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class DynamicBeam : MonoBehaviour
{
    public static MLInput.Controller controller;
    public static LineRenderer beamLine; 
    public Color startColor;
    public Color endColor;

    public static GameObject intersectedObject;
    // Start is called before the first frame update

    void Start()
    {
        controller = MLInput.GetController(MLInput.Hand.Left);
        beamLine = GetComponent<LineRenderer>();
        UpdateLineColor(Color.blue);
    }


    public static bool CheckTrigger() {
        if (controller.TriggerValue > 0.2f) {
            return true;
        }
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = controller.Position;
        transform.rotation = controller.Orientation;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            DefuseUIManager.statusText = hit.transform.gameObject.name;
            intersectedObject = hit.transform.gameObject;
            beamLine.useWorldSpace = true;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, transform.forward * 5);
            // if (DefuseMinigameManager.lineStarted == false)
                // UpdateLineColor(Color.yellow);
            if (hit.transform.gameObject.name == "Start Checkpoint") {
                intersectedObject = hit.transform.gameObject;
            } else {
                // beamLine.startColor = Color.blue;
            }
        }
        else
        {
            beamLine.useWorldSpace = true;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, transform.forward * 5);
            UpdateLineColor(Color.blue);
        }
    }

    public static void UpdateLineColor(Color newColor) {
        beamLine.startColor = newColor;
        beamLine.endColor = newColor;
    }
}

