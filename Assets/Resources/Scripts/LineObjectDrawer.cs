﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObjectDrawer : MonoBehaviour
{
    public GameObject LinePrefab;
    public List<Pair> PairsList;

    List<LineHandler> LinesList;

	void Start ()
    {
        AddAllLinesOnList();
    }

    LineHandler AddLine(Pair pair)
    {
        GameObject NewLineObj = Instantiate(LinePrefab, transform.position, Quaternion.identity, transform);
        LineHandler NewLine = NewLineObj.GetComponent<LineHandler>();
        NewLine.Pair = pair;
        NewLine.UpdatePoints();
        return NewLine;
    }
    void AddAllLinesOnList()
    {
        LinesList = new List<LineHandler>();
        foreach (Pair pair in PairsList)
        {
            LinesList.Add(AddLine(pair));
        }
    }
}
