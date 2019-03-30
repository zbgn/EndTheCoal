using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Elevator : MachineInterface
{
    public GameObject _TrainElevator;
    public bool _IsActivated;

    public override void Activate()
    {
        //Debug.Log("Activate");
        Debug.Log("Activate");
        if (_IsActivated == true)
        {
            _IsActivated = false;
        }
        else
        {
            _IsActivated = true;
        }
    }

    void Update()
    {
        if (_IsActivated == true)
        {
            if (_TrainElevator.transform.position.y < 12)
                _TrainElevator.transform.position = new Vector3(_TrainElevator.transform.position.x, _TrainElevator.transform.position.y + 0.5f * Time.deltaTime, _TrainElevator.transform.position.z);
        }
        else
        {
            if (_TrainElevator.transform.position.y > 2)
                _TrainElevator.transform.position = new Vector3(_TrainElevator.transform.position.x, _TrainElevator.transform.position.y - 0.5f * Time.deltaTime, _TrainElevator.transform.position.z);
        }
    }
}
