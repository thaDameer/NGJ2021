using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform guardTransform, chairTransform;
    [SerializeField] private float zOffset;
    [SerializeField] private float minXClamp, maxXClamp;
    [SerializeField] private float minZClam, maxZClamp;
  

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 middleCalculation = (guardTransform.position + chairTransform.position) / 2;
        middleCalculation.z += zOffset;
        middleCalculation.x = Mathf.Clamp(middleCalculation.x, minXClamp, maxXClamp);
        transform.position = middleCalculation;
    }
}
