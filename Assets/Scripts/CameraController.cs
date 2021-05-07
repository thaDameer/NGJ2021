using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform guardTransform, chairTransform;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 middleCalculation = (guardTransform.position + chairTransform.position) / 2;
        
        transform.position = middleCalculation;
    }
}
