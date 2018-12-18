using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour
{
    public int ClusterAmount;
    public List<mesh> Cluster = new List<mesh>();

	// Use this for initialization
	void Start ()
	{
	    for (int i = 0; i < ClusterAmount; i++)
	    {
	        mesh group = new mesh();
            Cluster.Add(group);
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
