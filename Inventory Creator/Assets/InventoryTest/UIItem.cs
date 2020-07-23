using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public int ID;
    public int SubID;
    public string ItemName;
    public int maxStack;
    public string TextureName;
    public string Description;
    public Texture2D Image;
    public double width;

    public int count;

    public GameObject Database;
    public Transform ItemPiece;
    private int counter = 1;
    private int scale = 16;

    public void InventDraw()
    {
        //Debug.Log("OOF");
        gameObject.transform.GetComponent<RawImage>().texture = Image;
        if (count != 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().text = count.ToString();
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }

    public void castToSelf(UIItem Item)
    {
        ID = Item.ID;
        SubID = Item.SubID;
        ItemName = Item.ItemName;
        maxStack = Item.maxStack;
        TextureName = Item.TextureName;
        Description = Item.Description;
        Image = Item.Image;
        width = Item.width;
        count = Item.count;
    }
}
