using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Rigidbody carRB;

    // Use this for initialization
    void Start ()
    {
        transform.position = new Vector3(0.0f, carRB.position.y + 7.0f, carRB.position.z - 5.0f);

    }

    // Update is called once per frame
    void Update ()
    {
        transform.position = new Vector3(0.0f, carRB.position.y + 7.0f, carRB.position.z - 5.0f);
    }
}
