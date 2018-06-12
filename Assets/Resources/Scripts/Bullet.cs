using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 1;

    Matrix2x2 MovmentTransformation;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position +=  (transform.up * Speed * Time.deltaTime);
	}
}
