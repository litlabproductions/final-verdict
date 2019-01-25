using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCamera : MonoBehaviour
{
    public Rigidbody heliRB;

    // Use this for initialization
    void Start ()
    {
        transform.position = new Vector3(0.0f, heliRB.position.y + 7.0f, heliRB.position.z - 5.0f);

    }

    // Update is called once per frame
    void Update ()
    {
        transform.position = new Vector3(0.0f, heliRB.position.y + 7.0f, heliRB.position.z - 5.0f);
    }
}
