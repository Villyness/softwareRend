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
    public MeshRenderer quadRenderer;
    public byte[] backBuffer;
    public Texture2D tex;
    public Star test;

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

        test = new Star();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ColourChange(0, 0, 0);

        PixelChange(Random.Range(0, ByteSize/3), Random.Range(0, ByteSize/3), Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));

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
