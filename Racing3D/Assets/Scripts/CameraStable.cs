using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour 
{
    public Rigidbody carRB;

    void Start()
    {
        transform.position = new Vector3(0.0f, carRB.position.y + 22.0f, carRB.position.z + 8.0f);
    }

    void Update()
    {
        transform.position = new Vector3(0.0f, carRB.position.y + 22.0f, carRB.position.z + 8.0f);
    }


     //  void ChangeCameraAngle()
    ///   {
     //      isCameraTopDown = !isCameraTopDown;
       //}
}
