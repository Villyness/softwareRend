﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rend : MonoBehaviour
{
    public int xSize;
    public int ySize;
    public int xCoord;
    public int Red;
    public int Green;
    public int Blue;
    public MeshRenderer quadRenderer;
    public byte[] backBuffer;
    public Texture2D tex;

    private int ByteSize;

    // Use this for initialization
    void Start ()
    {
        ByteSize = xSize * ySize * 3;
        backBuffer = new byte[ByteSize];

        /*backBuffer[0] = 255;
        backBuffer[21] = 255;
        backBuffer[22] = 255;
        backBuffer[23] = 255;*/

        
        tex = new Texture2D(xSize, ySize, TextureFormat.RGB24, false);
        tex.filterMode = FilterMode.Point; // Removes blurring
        quadRenderer.material.mainTexture = tex;


    }
	
	// Update is called once per frame
	void Update ()
    {
        tex.LoadRawTextureData(backBuffer);
        tex.Apply(false);
        ColourChange(Red, Green, Blue);
    }

    public void ColourChange(int R, int G, int B)
    {
        for (int i = 0; i < ByteSize; i++)
        {
            if (i % 3 == 0)
            {
                backBuffer[i] = (byte)R;
            }

            if ((i - 1) % 3 == 0)
            {
                backBuffer[i] = (byte)G;
            }

            if ((i - 2) % 3 == 0)
            {
                backBuffer[i] = (byte)B;
            }
        }
    }
}