using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix2x2
{
    public float a11, a12, a21, a22;

    public Matrix2x2()
    {
        a11 = 1; a12 = 0; a21 = 0; a22 = 1;
    }
    public Matrix2x2(float a11, float a21, float a12, float a22)
    {
        this.a11 = a11; this.a12 = a12; this.a21 = a21; this.a22 = a22;
    }
    public Matrix2x2(Vector2 colum1, Vector2 colum2)
    {
        a11 = colum1.x; a21 = colum1.y;
        a12 = colum2.x; a22 = colum2.y;
    }
    public string Str()
    {
        string Out = "[" + a11 + " " + a12 + "\n" + a21 + " " + a22 + "]";
        return Out;
    }
    public static Matrix2x2 operator *(Matrix2x2 m, float f)
    {
        return new Matrix2x2(m.a11 * f, m.a21 * f, m.a12 * f, m.a22 * f);
    }
    public static Vector2 operator *(Matrix2x2 m, Vector2 v)
    {
        Vector2 NewV = new Vector2(m.a11 * v.x + m.a12 * v.y, m.a21 * v.x + m.a22 * v.y);
        return NewV;
    }
    public Matrix2x2 Identity()
    {
        return new Matrix2x2(1, 0, 0, 1);
    }
    public Matrix2x2 Stretch(float alpha)
    {
        return new Matrix2x2(alpha, 0, 0, alpha);
    }
    public Matrix2x2 Rotation(float angle)
    {
        return new Matrix2x2(Mathf.Cos(angle), Mathf.Sin(angle), -Mathf.Sin(angle), Mathf.Cos(angle));
    }
    public Matrix2x2 Reflection(Vector2 mirrow)
    {
        return new Matrix2x2((1 - 2 * Mathf.Pow(mirrow.y, 2)), (-2 * mirrow.x * mirrow.y), (-2 * mirrow.x * mirrow.y), (1 - 2 * Mathf.Pow(mirrow.x, 2)));
    }

}
