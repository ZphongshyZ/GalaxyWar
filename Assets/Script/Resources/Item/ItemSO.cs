using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]

public class ItemSO : ScriptableObject
{
    public ItemCode pointsCode = ItemCode.NoItem;
    public string pointName = "Point";
    public int point = 0;
}