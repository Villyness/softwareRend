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
    public List<Star> Nova;

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

        Vector3 Pos = new Vector3(Random.Range(0, 16), Random.Range(0, 16), 0);

        test = new Star();
        for (int i = 0; i < 10; i++)
        {
            Pos.x = Random.Range(0, 16);
            Pos.y = Random.Range(0, 16);
            Star _star = new Star();
            _star.OwnPos = Pos;
            Nova.Add(_star);
        }

        foreach (Star star in Nova)
        {
            print(star.OwnPos);
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
	    test.OwnPos.x = Random.Range(0, 16);
	    test.OwnPos.y = Random.Range(0, 16);
	    //test.OwnPos.x = Random.Range(0, 16);

        ColourChange(0, 0, 0);

        PixelChange((int)test.OwnPos.x, (int)test.OwnPos.y, Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));

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
