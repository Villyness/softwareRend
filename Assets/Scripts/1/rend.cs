using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rend : MonoBehaviour // Just need to replace star with vertices
{
    public int xSize;
    public int ySize;

    public int Red;
    public int Green;
    public int Blue;

    public MeshRenderer quadRenderer;
    public byte[] backBuffer;

    public Texture2D tex;
    //public List<Star> Nova = new List<Star>();

    private int ByteSize;

    // Mesh stuff
    public List<mesh> CubeGroup = new List<mesh>();
    public List<vertex> meshVertex;
    public GameObject testObject;

    // Use this for initialization
    void Start()
    {
        ByteSize = xSize * ySize * 3;
        backBuffer = new byte[ByteSize];

        tex = new Texture2D(xSize, ySize, TextureFormat.RGB24, false);
        tex.filterMode = FilterMode.Point; // Removes blurring
        quadRenderer.material.mainTexture = tex;

        /*for (int i = 0; i < 10; i++)
        {
            Star star = new Star();
            Pos = new Vector3(Random.Range(0, 16), Random.Range(0, 16), 0);
            _star.OwnPos = Pos;
            Nova.Add(_star);
        }
        for(int i = 0; i < 10; i++)
        {
            mesh group = new mesh();
            CubeGroup.Add(group);
        }*/
        foreach (mesh cube in GetComponent<demo>().Cluster)
        {
            Debug.Log("Hello World!");
            CubeGroup.Add(cube);
            foreach (vertex corner in cube.Vertices)
            {
                meshVertex.Add(corner);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ColourChange(0, 0, 0);

        foreach (mesh cluster in CubeGroup)
        {
            Debug.Log("Hello World");
            foreach (vertex corner in meshVertex)
            {
                Instantiate(testObject, corner.OwnPos, Quaternion.identity);
            }
            if ((cluster.OwnPos.x) / (cluster.OwnPos.z) < 0) // If x/z were to give a negative value (and hence break the PixelChange()), then set it to positive/negative
            {
                cluster.OwnPos.x = (cluster.OwnPos.x) * (-1);
            }

            if ((cluster.OwnPos.y) / (cluster.OwnPos.z) < 0)
            {
                cluster.OwnPos.y = (cluster.OwnPos.y) * (-1);
            }

            if (((cluster.OwnPos.x % 16) / (cluster.OwnPos.z)) < 8 /*&& ((star.OwnPos.x % 16) / (star.OwnPos.z)) > 0*/
            ) // Reset the location after it goes below 1
            {
                Vector3 NewPos = new Vector3(Random.Range(8, 16), Random.Range(8, 16), -1);
                cluster.OwnPos = NewPos;
            }

            PixelChange((int) (((cluster.OwnPos.x % 16 + (cluster.OwnPos.x)) / (cluster.OwnPos.z)) / 2),
                (int) (((cluster.OwnPos.y % 16 + (cluster.OwnPos.y)) / (cluster.OwnPos.z)) / 2), 255, 255,
                255); // Call the function to draw the stars
        }

        tex.LoadRawTextureData(backBuffer);
        tex.Apply(false);
    }

    public void ColourChange(int R, int G, int B)
    {
        for (int i = 0; i < ByteSize / 3; i++)
        {
            PixelChange(i, 0, R, G, B);
        }
    }

    public void PixelChange(int x, int y, int R, int G, int B)
    {
        /*if (((star.OwnPos.y % 16) / (star.OwnPos.z)) < 1 && ((star.OwnPos.y % 16) / (star.OwnPos.z)) > 0)
{
    Vector3 NewPos = new Vector3(Random.Range(0, 16), Random.Range(0, 16), -1);
    star.OwnPos = NewPos;
}

star.Update();
Debug.Log((star.OwnPos.x % 16) / (star.OwnPos.z));*/

        // Need to refactor it to take cubes
        backBuffer[(xSize * 3 * y) + (x * 3)] = (byte) R;
        backBuffer[(xSize * 3 * y) + ((x * 3) + 1)] = (byte) G;
        backBuffer[(xSize * 3 * y) + ((x * 3) + 2)] = (byte) B;
    }

    /*public void SpawnCubes()
    {
        for (i = 0; i < 4; i++)
        {
            mesh cubeCluster = new mesh();

        }
    }*/
}