using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour 
{
    public Rigidbody carRB;

    void Start()
    {
        transform.position = new Vector3(carRB.position.x, carRB.position.y + 80.0f, carRB.position.z + 15.0f);
    }

    void Update()
    {
        transform.position = new Vector3(carRB.position.x, carRB.position.y + 80.0f, carRB.position.z + 15.0f);
    }


     //  void ChangeCameraAngle()
    ///   {
     //      isCameraTopDown = !isCameraTopDown;
       //}
}
