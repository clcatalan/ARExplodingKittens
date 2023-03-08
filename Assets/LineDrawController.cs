using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawController : MonoBehaviour
{
    [SerializeField] private LineRenderer line;

    public void SetPosition(Vector2 pos) {
        if (!CanDraw(pos)) return;

        line.positionCount++;
        line.SetPosition(line.positionCount - 1, LineManager.GetWorldCoordinate(DynamicBeam.hit.point));
    }

    private bool CanDraw(Vector2 pos) {
        if (line.positionCount == 0) {
            return true;
        }


        return Vector3.Distance(line.GetPosition(line.positionCount - 1), pos) > LineManager.RESOLUTION;
    }
}
