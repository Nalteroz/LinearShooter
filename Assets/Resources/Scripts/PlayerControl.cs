using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject BulletPrefab;
    public float MovmentSpeed = 10, BulletCoolDonw = 0.1f;

    float LastTimeShootBullet = 0;
    float ScreenVerticalLimit = Screen.height / 2, ScreenHorisontalLimit = Screen.width/2;
	// Use this for initialization
	void Start ()
    {
        if (!BulletPrefab) BulletPrefab = Resources.Load<GameObject>("Prefabs/" + "PlayerBullet");
        if (!MainCamera) MainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInput();
    }

    public void Shoot()
    {
        if (Time.time - LastTimeShootBullet > BulletCoolDonw)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            LastTimeShootBullet = Time.time;
        }
    }

    public enum Side
    { Left, Right, Up, Down}

    public void CheckInput()
    {
        Vector3 InCameraPosition = MainCamera.WorldToScreenPoint(transform.position);
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (InCameraPosition.x < Screen.width)
                Move(Side.Right);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (InCameraPosition.x > 0)
                Move(Side.Left);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            if (InCameraPosition.y > 0)
                Move(Side.Down);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            if (InCameraPosition.y < Screen.height)
                Move(Side.Up);
        }
        if (Input.GetAxis("Fire1") > 0)
        {
            Shoot();
        }
    }

    public void Move(Side direction)
    {
        Vector2 dVector = Vector2.zero;
        switch(direction)
        {
            case Side.Left:
                dVector = Vector2.left;
                break;
            case Side.Right:
                dVector = Vector2.right;
                break;
            case Side.Up:
                dVector = Vector2.up;
                break;
            case Side.Down:
                dVector = Vector2.down;
                break;
        }
        transform.position += (Vector3)(dVector * MovmentSpeed * Time.deltaTime);
    }

}
