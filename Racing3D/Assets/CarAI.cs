using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{

    Rigidbody carAIRB;

	// Use this for initialization
	void Start ()
    {
        carAIRB = GetComponent<Rigidbody>();
        carAIRB.velocity = new Vector3(0f, 0f, 5f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        carAIRB.velocity = new Vector3(0f, 0f, 5f);

    }
}
