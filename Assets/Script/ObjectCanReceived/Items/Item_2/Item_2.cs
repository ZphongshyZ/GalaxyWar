using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_2 : ItemReceived
{
    protected override void Upgrade()
    {
        ShieldOfShip.Instance.IsShielding = true;
    }
}
