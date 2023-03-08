using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class DynamicBeam : MonoBehaviour
{

    public GameObject controller;
    private LineRenderer beamLine;

    public Color startColor;
    public Color endColor;

    public MLInput.Controller mlController;
    public GameObject cube;

    public static RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        beamLine = GetComponent<LineRenderer>();
        beamLine.startColor = startColor;
        beamLine.endColor = endColor;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;


        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            beamLine.useWorldSpace = true;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, hit.point);
            cube.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            beamLine.useWorldSpace = false;
            cube.GetComponent<MeshRenderer>().enabled = true;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, Vector3.forward * 5);
        }

    }

    public static bool OnButton(MLInput.Controller.Button button) {
        if (button == MLInput.Controller.Button.Bumper) {
            return true;
        }
        return false;
    }

    private bool CheckTrigger() {
        return mlController.TriggerValue > 0.2f;
    }


    
}
