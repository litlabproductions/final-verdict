using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public Transform playerPosition;

    private Vector3 _heliOffset;

    public AudioSource heliSoundFX;
    public AudioSource heliChatterFX;

    [RangeAttribute(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;


	// Use this for initialization
	void Start ()
    {
        _heliOffset = transform.position - playerPosition.position;

        heliSoundFX.Play();
        StartCoroutine(PlayChatter());
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPos = new Vector3 (playerPosition.position.x + _heliOffset.x , playerPosition.position.y + 10.0f + _heliOffset.y, playerPosition.position.z - 3.0f + _heliOffset.z);
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
	}

    private IEnumerator PlayChatter()
    {
        yield return new WaitForSeconds(5);
        heliChatterFX.Play();
    }
}




