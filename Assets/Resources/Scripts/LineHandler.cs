using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour
{
    public Pair Pair;

    LineRenderer Line;

	void Start ()
    {
        Line = GetComponent<LineRenderer>();
        UpdatePoints();
	}
    public void UpdatePoints()
    {
        if (Line == null) Line = GetComponent<LineRenderer>();
        Line.SetPositions(new Vector3[] { Pair.Point1, Pair.Point2 });
    }
    public void ApplyTransformation(Matrix2x2 Transformation)
    {
        Pair.Point1 = Transformation * Pair.Point1;
        Pair.Point2 = Transformation * Pair.Point2;
        UpdatePoints();
    }
}

[System.Serializable]
public class Pair
{
    public Vector2 Point1, Point2;

    public Pair(Vector2 p1, Vector2 p2)
    {
        Point1 = p1; Point2 = p2;
    }
}
