using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rend : MonoBehaviour
{
    public int xSize;
    public int ySize;
    public int xCoord;
    public int yCoord;

    public int Red;
    public int Green;
    public int Blue;

    public Camera mainCam;

    public MeshRenderer quadRenderer;
    public byte[] backBuffer;
    public Texture2D tex;
    public List<Star> Nova = new List<Star>();
    public Vector3 Pos;

    public bool Clear;

    private int ByteSize;

    // Use this for initialization
    void Start ()
    {
        ByteSize = xSize * ySize * 3;
        backBuffer = new byte[ByteSize];

        tex = new Texture2D(xSize, ySize, TextureFormat.RGB24, false);
        tex.filterMode = FilterMode.Point; // Removes blurring
        quadRenderer.material.mainTexture = tex;

        for (int i = 0; i < 10; i++)
        {
            Star _star = new Star();
            Pos = new Vector3(Random.Range(0, 16), Random.Range(0, 16), 0);
            _star.OwnPos = Pos;
            Nova.Add(_star);
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
	    ColourChange(0, 0, 0);

        foreach (Star star in Nova)
        {
            //print(star);
            star.Start();
            //print(star.OwnPos.z);
            if ((star.OwnPos.x)/(star.OwnPos.z) < 0 /*|| (star.OwnPos.y)/(star.OwnPos.z) < 0 || (star.OwnPos.x%17) > xSize +2 || star.OwnPos.y > ySize +2*/)
            {
                star.OwnPos.x = (star.OwnPos.x) * (-1);
                //Debug.Log((star.OwnPos.x));
                //Debug.Log(xSize - 1);
                //return;
            }
            PixelChange((int)((star.OwnPos.x%16)/(star.OwnPos.z)), (int)((star.OwnPos.x % 16) / (star.OwnPos.z)), 255, 255, 255);
            //print((star.OwnPos.x % 17)/(star.OwnPos.z));
            
            star.Update(mainCam.transform.position);
            Debug.Log((star.OwnPos.x % 16) / (star.OwnPos.z));
        }

        tex.LoadRawTextureData(backBuffer);
        tex.Apply(false);
    }

    public void ColourChange(int R, int G, int B)
    {
        for (int i = 0; i < ByteSize/3; i++)
        {
            PixelChange(i, 0, R, G, B);
        }
    }

    public void PixelChange(int x, int y, int R, int G, int B)
    {
        backBuffer[(xSize * 3 * y) + (x * 3)] = (byte)R;
        //Debug.Log((xSize * 3 * y) + (x * 3));
        backBuffer[(xSize * 3 * y) + ((x * 3) + 1)] = (byte)G;
        backBuffer[(xSize * 3 * y) + ((x * 3) + 2)] = (byte)B;
    }
}
