using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryTruckConsole : MachineInterface
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Activate()
    {
        Debug.Log("Activate truck !");
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
