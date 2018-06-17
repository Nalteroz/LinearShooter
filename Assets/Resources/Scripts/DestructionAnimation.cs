using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionAnimation : MonoBehaviour
{
    public float Duration = 2f, StepDeslocation = 1, RotateAngle = 1;
    public bool Rotate = false;

    public bool Activate = false;
    LineObjectDrawer LineObject;
    Matrix2x2 RotationMatrix = new Matrix2x2();
    float StartTime = 0;
    PolygonCollider2D pCollider;
	void Start ()
    {
        LineObject = GetComponent<LineObjectDrawer>();
        RotationMatrix = RotationMatrix.Rotation(RotateAngle * Time.deltaTime);
        pCollider = GetComponent<PolygonCollider2D>();
	}
	
	void Update ()
    {
        if (Activate)
        {
            if (Time.time - StartTime < Duration)
            {
                AnimateOneStep();
                pCollider.enabled = false;
            }
            else
                Destroy(gameObject);
        }
        else
            StartTime = Time.time;
	}

    void AnimateOneStep()
    {
        foreach(LineHandler line in LineObject.LinesList)
        {
            Vector2 Diff = line.Pair.Point2 - line.Pair.Point1, LineDirection = Diff * 0.5f;
            Vector2 Middle = line.Pair.Point1 + LineDirection;
            Middle += Middle.normalized * StepDeslocation * Time.deltaTime;
            if (Rotate) LineDirection = RotationMatrix * LineDirection;
            line.Pair = new Pair(Middle - LineDirection, Middle + LineDirection);
            line.UpdatePoints();
        }
    }
}
