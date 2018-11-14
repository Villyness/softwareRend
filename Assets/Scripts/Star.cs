using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star
{
    public Vector3 OwnPos;

    public void Update()
    {
        OwnPos.x += 1*Time.deltaTime;
        //OwnPos.y += 1;
    }
}
