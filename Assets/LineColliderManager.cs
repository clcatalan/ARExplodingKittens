using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColliderManager : MonoBehaviour
{
    [SerializeField] private GameObject EndPoints;

    private Transform pointA;
    private Transform pointB;

    private void Start() {
        EndPoints = GameObject.Find("EndPoints");
        pointA = EndPoints.transform.GetChild(0);
        pointB = EndPoints.transform.GetChild(1);

    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("THIS WAS HIT");
    }
}
