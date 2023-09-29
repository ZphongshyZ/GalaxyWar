using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Point", menuName = "ScriptableObject/Point")]

public class PointSO : ScriptableObject
{
    public PointsCode pointsCode = PointsCode.NoItem;
    public string pointName = "Point";
}