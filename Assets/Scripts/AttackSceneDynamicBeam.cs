using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class AttackSceneDynamicBeam : MonoBehaviour
{
    public static MLInput.Controller controller;
    public static LineRenderer beamLine;
    public Color startColor;
    public Color endColor;
    // Start is called before the first frame update

    void Start()
    {
        controller = MLInput.GetController(MLInput.Hand.Left);
        beamLine = GetComponent<LineRenderer>();

        beamLine.startColor = startColor;
        beamLine.endColor = endColor;
    }


    public static bool CheckTrigger() {
        if (controller.TriggerValue > 0.2f) {
            return true;
        }
        return false;
    }


//     // Update is called once per frame
    void Update()
    {
        transform.position = controller.Position;
        transform.rotation = controller.Orientation;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            beamLine.useWorldSpace = true;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, hit.point);
            if (hit.transform.gameObject.name == "CryingKitten") {
            //if(hit.transform.gameObject.name == "CryingKitten")
                beamLine.startColor = Color.green;
                if(CheckTrigger()) {
                    //destroy object
                    //Object.Destroy(hit.transform.gameObject);
                    //kittenObject.GetComponent<CryingKitten>();
                    hit.transform.gameObject.GetComponent<CryingKitten>().KittenClicked();
                }
            } else {
                beamLine.startColor = Color.blue;
            }
        }
        else
        {
            beamLine.useWorldSpace = true;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, transform.forward * 5);
        }
    }
}

