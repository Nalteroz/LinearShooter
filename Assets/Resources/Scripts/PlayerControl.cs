using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject BulletPrefab;
    public float MovmentSpeed = 5, BulletCoolDonw = 0.1f, RotationAngle = 1;
    public bool CanMove = true;

    float LastTimeShootBullet = 0;
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
            Instantiate(BulletPrefab, transform.position + transform.up * 2, transform.rotation);
            LastTimeShootBullet = Time.time;
        }
    }

    public enum Side
    { Left, Right, Up, Down}
    public enum Rotate
    { Left, Right }

    public void CheckInput()
    {
        if (CanMove)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Move(Side.Right);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                Move(Side.Left);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                Move(Side.Down);
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                Move(Side.Up);
            }
            if (Input.GetAxis("Fire1") > 0)
            {
                Shoot();
            }
        }
    }

    public void Move(Side direction)
    {
        Vector2 dVector = Vector2.zero;
        if(direction == Side.Up || direction == Side.Down)
        {
            if (direction == Side.Up) dVector = transform.up;
            else dVector = -transform.up;
            transform.position += (Vector3)(dVector * MovmentSpeed * Time.deltaTime);
        }
        if (direction == Side.Left || direction == Side.Right) RotateShip(direction);
    }

    void RotateShip(Side direction)
    {
        Matrix2x2 Rot = new Matrix2x2();
        float angle = RotationAngle * Time.deltaTime;
        if (direction == Side.Right) angle *= -1;
        Rot = Rot.Rotation(angle);
        transform.up = Rot * transform.up;
        transform.right = Rot * transform.right;
    }

}
