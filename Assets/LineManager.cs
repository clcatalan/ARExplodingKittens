using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class LineManager : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private LineDrawController linePrefab;
    private LineDrawController currentLine;

    Ray ray;

    public const float RESOLUTION = 0.05f;

    private void Start() {
        _camera = Camera.main;
    }

    private void Update() {

        Vector3 mousePos = GetWorldCoordinate(DynamicBeam.hit.point);
        if (DynamicBeam.OnButton(MLInput.Controller.Button.Bumper)) {
            currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
        }

        if (DynamicBeam.OnButton(MLInput.Controller.Button.Bumper)) {
            currentLine.SetPosition(mousePos);
        }

    }

    public static Vector3 GetWorldCoordinate(Vector3 pos) {
        Vector3 mousePos = new Vector3(pos.x, pos.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
