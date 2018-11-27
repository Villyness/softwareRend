using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star
{
    public Vector3 OwnPos;
    private bool executed = true;

    public void Start()
    {
        if (executed == true)
        {
            OwnPos.z = -1;
            /*OwnPos.x = 15;
            OwnPos.y = 15;*/
            executed = false;
        }
    }

    public void Update(Vector3 camera)
    {
        OwnPos.x += 1*Time.deltaTime;
        OwnPos.y += 1 * Time.deltaTime;
        //OwnPos.y += 1;
        OwnPos.z -= 1 * Time.deltaTime;
    }

    public void Reset()
    {
        if(OwnPos.x >= 16)
        {
            OwnPos.x = 0;
        }
    }
}
