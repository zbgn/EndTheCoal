using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryTruckConsole : MachineInterface
{

    public GameObject _Grappin;
    public GameObject _Cord1;
    public GameObject _Cord2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Activate()
    {
        Debug.Log("Activate truck !");
        StartCoroutine(LiftContainer());
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LiftContainer()
    {

        while (_Grappin.transform.position.y < 5.0f)
        {
            yield return new WaitForSeconds(0.1f);
            _Cord1.transform.localScale = new Vector3(1, _Cord1.transform.localScale.y - 0.1f, 1);
            _Cord2.transform.localScale = new Vector3(1, _Cord2.transform.localScale.y - 0.1f, 1);
            _Grappin.transform.position = new Vector3(_Grappin.transform.position.x, _Grappin.transform.position.y + 0.5f, _Grappin.transform.position.z);
        }
    }

}
