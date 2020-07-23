using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Create3D : MonoBehaviour {
    public Texture2D Image;
    public Texture2D[] Images;
    public int imageSize = 64;
    public int width;
    public int scale = 10;
    public Transform SwordPiece;
    public Transform padre;
    public bool Sheathe=false;
    
	void Start () {
		

	}
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Sheathe = !Sheathe;
            SheatheWeapon();
        }
    }

    void SheatheWeapon()
    {
        if (Sheathe)
        {
            for (int y = 1; y < imageSize; y++)
            {
                for (int x = 1; x < imageSize; x++)
                {
                    if (Image.GetPixel(x, y) != Color.white)
                    {
                        Transform cube = Instantiate(SwordPiece, new Vector3(x, y, 0), Quaternion.identity);
                        cube.transform.parent = padre;
                        cube.transform.rotation = padre.rotation;
                        cube.transform.localPosition = new Vector3(x, y, 0) / scale;
                        cube.transform.localScale = new Vector3(1, 1, width) / scale;
                        cube.GetComponent<Renderer>().material.SetColor("_Color", Image.GetPixel(x, y));
                        cube.GetComponent<BoxCollider>().enabled = false;
                        Debug.Log(y + " , " + x);
                    }
                }
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

}
