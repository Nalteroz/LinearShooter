using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundariesHandler : MonoBehaviour
{

    Camera MainCamera;
	// Use this for initialization
	void Start ()
    {
        MainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckIfOutOfScreen();
	}

    public void CheckIfOutOfScreen()
    {
        Vector2 ScreenPositioning = MainCamera.WorldToScreenPoint(transform.position);
        if ((ScreenPositioning.x > Screen.width) || (ScreenPositioning.x < 0) || (ScreenPositioning.y > Screen.height) || (ScreenPositioning.y < 0))
        {
            transform.position *= -1;
        }
    }
}
