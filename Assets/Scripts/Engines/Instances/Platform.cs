using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MachineInterface
{

    public override void Activate()
    {
        if (GameObject.FindObjectOfType<Player2>().GetMachine().GetMachineType() == MachineType.JUMPER)
        {
            GameObject.FindObjectOfType<Player2>().GetComponent<Player2>().Jump(5.0f);
        }
    }

    public override MachineType GetMachineType()
    {
        return MachineType.PLATFORM;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
