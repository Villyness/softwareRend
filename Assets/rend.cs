using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rend : MonoBehaviour
{
    public int xSize;
    public int ySize;
    public MeshRenderer quadRenderer;
    public byte[] backBuffer;
    //public Texture2D tex;

	// Use this for initialization
	void Start ()
    {
        byte[] backBuffer = new byte[(xSize*ySize*3)];
        backBuffer[0] = 255;
        backBuffer[4] = 255;

        Texture2D tex = new Texture2D(xSize, ySize, TextureFormat.RGB24, false);
        tex.filterMode = FilterMode.Point; // Removes blurring
        quadRenderer.material.mainTexture = tex;
        tex.LoadRawTextureData(backBuffer);
        tex.Apply(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
