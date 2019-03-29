using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    //To override
    //Used to make an action on object with tag "interact"
    public virtual void Action()
    {
        Debug.Log("MUST OVERIDE ACTION");
    }
}
