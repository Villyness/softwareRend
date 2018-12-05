using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesh : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public Vector3 OwnPos;
    public vertex[] Vertices;
    //public Vector3[] vertexPos;

    public float Displacement = 0.5f;

    // Use this for initialization
    void Start ()
    {
        OwnPos = new Vector3(0, 0, 0);

        Vertices = new vertex[8];

        Vertices[0] = new vertex(new Vector3(OwnPos.x-Displacement, Displacement, -Displacement));
        Vertices[1] = new vertex(new Vector3(Displacement, Displacement, -Displacement));
        Vertices[2] = new vertex(new Vector3(-Displacement, -Displacement, -Displacement));
        Vertices[3] = new vertex(new Vector3(Displacement, -Displacement, -Displacement));
        Vertices[4] = new vertex(new Vector3(-Displacement, Displacement, Displacement));
        Vertices[5] = new vertex(new Vector3(Displacement, Displacement, Displacement));
        Vertices[6] = new vertex(new Vector3(-Displacement, -Displacement, Displacement));
        Vertices[7] = new vertex(new Vector3(Displacement, -Displacement, Displacement));

        for (int i = 0; i <8; i++)
        {
            
            Instantiate(ObjectToSpawn, Vertices[i].OwnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
