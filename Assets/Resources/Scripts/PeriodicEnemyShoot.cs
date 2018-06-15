using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicEnemyShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletCoolDonw = 0.5f, RotationCoolDonw = 0.7f, RotationAngle = 0.2f, MovmentSpeed = 5, MinDistanceToLock = 20;

    GameObject PlayerObject;
    float LastTimeShootBullet = 0, LastTimeChooseDirection = 0;
    Rotate direction;


    void Start ()
    {
        PlayerObject = GameObject.Find("PlayerShip");
	}
	void Update ()
    {
        if((PlayerObject.transform.position - transform.position).magnitude <= MinDistanceToLock) LookAt(PlayerObject.transform.position);
        else
        {
            ChooseRotationDirection();
            RotateShip(direction);
        }
        MoveFoward();
        Shoot();
	}
    void ChooseRotationDirection()
    {
        if (Time.time - LastTimeChooseDirection > RotationCoolDonw)
        {
            direction = (Rotate) Random.Range(0, 2);
            LastTimeChooseDirection = Time.time;
        }
    }
    void LookAt(Vector3 position)
    {
        Vector2 diff = position - transform.position;
        transform.up = diff.normalized;
    }
    void Shoot()
    {
        if (Time.time - LastTimeShootBullet > BulletCoolDonw)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            LastTimeShootBullet = Time.time;
        }
    }
    public enum Rotate
    { Left, Right}
    void RotateShip (Rotate direction)
    {
        Matrix2x2 Rot = new Matrix2x2();
        float angle = RotationAngle * Time.deltaTime;
        if (direction == Rotate.Right) angle *= -1;
        Rot = Rot.Rotation(angle);
        transform.up = Rot * transform.up;
        transform.right = Rot * transform.right;
    }
    void MoveFoward()
    {
        transform.position += MovmentSpeed * Time.deltaTime * transform.up;
    }

}
