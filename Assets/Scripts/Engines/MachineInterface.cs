using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MachineType
{
    PLATFORM = 0,
    JUMPER = 1,
    OTHER = 2
}


[System.Serializable]
public class MachineInterface : MonoBehaviour
{

    public virtual MachineType GetMachineType()
    {
        return MachineType.OTHER;
    }

    public virtual void Activate()
    {

    }
}
