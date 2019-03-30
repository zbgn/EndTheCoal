using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryGate : MachineInterface
{
    public GameObject _Door;
    
    public override void Activate()
    {
        this._Door.GetComponent<PolygonCollider2D>().enabled = false;
    }
}
