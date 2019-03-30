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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerBase>() != null)
        {
            other.gameObject.GetComponent<PlayerBase>().enableInteraction(this);
            Debug.Log(this.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerBase>().disableInteraction();
        Debug.Log(this.gameObject.name);
    }


}
