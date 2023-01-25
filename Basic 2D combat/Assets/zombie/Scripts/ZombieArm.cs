using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieArm : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private DistanceJoint2D distanceJoint;

    private void Update()
    {
        //hookRB.transform.position = gameObject.transform.position;
    }
}
