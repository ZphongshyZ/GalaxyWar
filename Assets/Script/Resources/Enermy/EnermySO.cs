using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enermy", menuName = "ScriptableObject/Enermy")]

public class EnermySO : ScriptableObject
{
    public string enermyName = "Enermy";
    public int hpMax = 2;

    public List<PointDropRate> pointDropList;

    public List<ItemDropRate> itemDropList;
}
